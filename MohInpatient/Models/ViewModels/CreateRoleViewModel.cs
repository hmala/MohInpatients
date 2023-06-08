using System.ComponentModel.DataAnnotations;

namespace MohInpatient.Models
{
    public class CreateRoleViewModel
    {
        [Required]
        public string? RoleName { get; set; }
    }

}
