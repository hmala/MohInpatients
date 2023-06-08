using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using MohInpatient.Models;
using MohInpatient.Models.ViewModels;

namespace MohInpatient.Controllers
{
   // [Authorize]
    public class AccountController : Controller
    {
        #region configuration
        private UserManager<ApplicationUser> userManager;
        private SignInManager<ApplicationUser> signInManager;
        private RoleManager<IdentityRole> roleManager;
        public AccountController(UserManager<ApplicationUser> _userManager,
                                 SignInManager<ApplicationUser> _signInManager,
                                 RoleManager<IdentityRole> _roleManager)
        {
            userManager = _userManager;
            signInManager = _signInManager;
            roleManager = _roleManager;

        }
        #endregion

        #region Authz&Authz

        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser
                {
                    UserName = model.UserEmail,
                    Email = model.UserEmail,
                    PhoneNumber = model.Phone,
                    Gender = model.Gender,
                    Address = model.Address
                };
                var result = await userManager.CreateAsync(user, model.Password!);
                if (result.Succeeded)
                {
                    return RedirectToAction("login", "Account");
                }
                foreach (var err in result.Errors)
                {
                    ModelState.AddModelError(err.Code, err.Description);
                }
                return View(model);
            }
            return View(model);
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult login()

        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(
                       model.UserEmail!,
                       model.Password!,
                       model.RememberMe,
                       false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Wrong email or password");

                return View(model);
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("login", "Account");
        }

        #endregion

        #region users
       // [Authorize(Roles = "Admin")]

        [HttpGet]
        public IActionResult AllUsers()
        {
            return View(userManager.Users);
        }
    //    [Authorize(Roles = "Admin")]

        [HttpGet]
        public IActionResult CreateUser()
        {
            return View();

        }
    //    [Authorize(Roles = "Admin")]

        public async Task<IActionResult> CreateUser(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser
                {
                    UserName = model.UserEmail,
                    Email = model.UserEmail,
                    PhoneNumber = model.Phone,
                    Gender = model.Gender,
                    Address = model.Address
                };
                var result = await userManager.CreateAsync(user, model.Password!);
                if (result.Succeeded)
                {
                    return RedirectToAction("AllUsers", "Account");
                }
                foreach (var err in result.Errors)
                {
                    ModelState.AddModelError(err.Code, err.Description);
                }
                return View(model);
            }
            return View(model);
        }

        #endregion
        #region roles
     //   [Authorize(Roles ="Admin")]
        public IActionResult RolesList()
        {

            return View(roleManager.Roles);
        }
  //      [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> EditRole(string? id)
        {
            var roleData = await roleManager.FindByIdAsync(id);
            if (roleData == null)
            {
                return RedirectToAction(nameof(RolesList));
            }
            EditRoleViewModel model = new EditRoleViewModel
            {
                RoleId = roleData.Id,
                RoleName = roleData.Name
            };
            foreach (var user in userManager.Users)
            {
                if (await userManager.IsInRoleAsync(user, model.RoleName!))
                {
                    model.Users!.Add(user.UserName!);
                }
            }
            return View(model);
        }
  //      [Authorize(Roles = "Admin")]

        [HttpPost]
        public async Task<IActionResult> EditRole(EditRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var role = await roleManager.FindByIdAsync(model.RoleId!);
                if (role == null)
                {
                    return RedirectToAction(nameof(RolesList));
                }
                role.Name = model.RoleName;
                var result = await roleManager.UpdateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(RolesList));
                }
                foreach (var err in result.Errors)
                {
                    ModelState.AddModelError(err.Code, err.Description);
                }
                return View(model);
            }
            return View(model);

        }
    //    [Authorize(Roles = "Admin")]

        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }
   //     [Authorize(Roles = "Admin")]

        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityRole role = new IdentityRole
                {
                    Name = model.RoleName
                };
                var resukt = await roleManager.CreateAsync(role);
                if (resukt.Succeeded)
                {
                    return RedirectToAction(nameof(RolesList));

                }
                foreach (var err in resukt.Errors)
                {
                    ModelState.AddModelError(err.Code, err.Description);
                    return View(model);

                }
                return View(model);

            }
            return View(model);

        }
  //      [Authorize(Roles = "Admin")]

        [HttpGet]
        public async Task<IActionResult> AddRemoveUsersRole(string? id)
        {
            var role = await roleManager.FindByIdAsync(id);
            if (role == null)
            {
                return RedirectToAction(nameof(NotFountData));
            }
            if (id == null) { return RedirectToAction(nameof(NotFountData)); }
            var models = new List<AddRemoveUsersRoleViewModel>();

            foreach (var user in userManager.Users)
            {
                var model = new AddRemoveUsersRoleViewModel
                {
                    UserName = user.UserName,
                    UserId = user.Id
                };

                if (await userManager.IsInRoleAsync(user, role.Name!))
                {
                    model.IsSelected = true;
                }
                else
                {
                    model.IsSelected = false;
                }

                models.Add(model);
            }
            return View(models);
        }
   //     [Authorize(Roles = "Admin")]

        [HttpPost]
        public async Task<IActionResult> AddRemoveUsersRole(List<AddRemoveUsersRoleViewModel> models, string? Id)
        {
            var role = await roleManager.FindByIdAsync(Id);
            if (role == null) { return RedirectToAction(nameof(NotFountData)); }
            if (Id == null) { return RedirectToAction(nameof(NotFountData)); }
            IdentityResult result = null;
            for (int i = 0; i < models.Count; i++)
            {
                var user = await userManager.FindByIdAsync(models[i].UserId!);
                if (models[i].IsSelected == true && !(await userManager.IsInRoleAsync(user!, role.Name!)))
                {
                    result = await userManager.AddToRoleAsync(user!, role.Name);
                }
                else if (!models[i].IsSelected == true && await userManager.IsInRoleAsync(user!, role.Name!))
                {
                    result = await userManager.RemoveFromRoleAsync(user!, role.Name);
                }
               
            }
                return View(models);

            }
            public IActionResult NotFountData()
            {
                ViewBag.errorItem = "NOT FOUND";
                return View();

            }
        public IActionResult AccessDenied()
        {
           
            return View();

        }
        #endregion


    }
    }
