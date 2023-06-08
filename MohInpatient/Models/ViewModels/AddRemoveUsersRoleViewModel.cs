using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace MohInpatient.Models
{
    public class AddRemoveUsersRoleViewModel
    {
        [Display(Name= "User Id")]
        public string UserId { get; set; }

        [Display(Name = "User Name")]
      public string UserName { get; set; }

        [Display(Name = "In Role")]
        public bool IsSelected { get; set;}  
    }
}
