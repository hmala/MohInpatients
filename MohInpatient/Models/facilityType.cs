using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MohInpatient.Models
{
    public class facilityType
    {
        [Key]
        public int FacTyId { get; set; }
        public int FacTyCode { get; set; }

        public string? FacTyName { get; set; }
        [ForeignKey("Doh")]
        public int DohId { get; set; }
        public Doh Doh { get; set; }
    }
}
