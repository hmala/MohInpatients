using System.ComponentModel.DataAnnotations;

namespace MOHIdentity.Models
{
    public class EditRoleViewModel
    {
        public EditRoleViewModel()
        {
            Users = new List<string>();
        }
        public string? RoleId { get; set; }
        [Required(ErrorMessage ="Enter Role Name")]
        [Display(Name="Role Name")]
        public string? RoleName { get; set; }
        public List<string>? Users { get; set; }
    }
}
