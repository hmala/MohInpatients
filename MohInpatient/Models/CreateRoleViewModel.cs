using System.ComponentModel.DataAnnotations;

namespace MOHIdentity.Models
{
    public class CreateRoleViewModel
    {
        [Required]
        public string? RoleName { get; set; }
    }

}
