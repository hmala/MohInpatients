using System.ComponentModel.DataAnnotations.Schema;

namespace MohInpatient.Models
{
    public class Doh
    {
        public int DohId { get; set; } 
        public int DohCode { get; set; }
        public string DohName { get; set; }
        [NotMapped]
        public int FacTyId { get; set; }
        [NotMapped]
        public int FacId { get; set; }

    }
}
