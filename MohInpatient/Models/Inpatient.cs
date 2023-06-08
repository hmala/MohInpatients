using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using static MohInpatient.Models.grouplist;

namespace MohInpatient.Models
{
    public class Inpatient: grouplist
    {
        [Key]
        public int InpatientId { get; set; }
        [DisplayName("رقم الوحدة")]
        public int UnitNum { get; set; }
        [Required]
        [DisplayName("اختصاص الوحدة الطبية")]
        public string? SpeUnit { get; set; }
        [Required]
        [DisplayName("دائرة الصحة")]
        public string? DohCode { get; set; }
        [Required]
        [DisplayName("المستشفى")]
        public string? FacName { get; set; }
        [Required]
        [DisplayName("الناحية")]
        public int NahiaId { get; set; }
        [Required]
        [DisplayName("القضاء")]
        public int kADAId { get; set; }
        [Required]
        [DisplayName("المحافظة")]
        public int GovId { get; set; }
        [Required(ErrorMessage ="ادخال الاسم")]
        [DisplayName("اسم المريض")]
        public string? FPaName { get; set; }
        [Required(ErrorMessage = "ادخال الاسم")]
        public string? SPaName { get; set; }
        [Required(ErrorMessage = "ادخال الاسم")]
        public string? TPaName { get; set; }
        [Required(ErrorMessage = "ادخال الاسم")]
        public string? FoPaName { get; set; }
        [Required(ErrorMessage = "ادخال الاسم")]
        [DisplayName("اسم الام")]
        public string? FMoName { get; set; }
        [DisplayName("اسم والد الام")]
        [Required(ErrorMessage = "ادخال الاسم")]
        public string? SMoName { get; set; }
        [DisplayName("اسم جد الام")]
        [Required(ErrorMessage = "ادخال الاسم")]
        public string? TMoName { get; set; }
        [Required]
        [DisplayName("الجنس")]
        public Gender Gender { get; set; }
        [Required]
        [DisplayName("التحصيل الدراسي")]
        public Education Education { get; set; }
        [Required]
        [DisplayName("المهنة")]
        public job job { get; set; }
        [Required]
        [DisplayName("العمر")]
        public int Age { get; set; }
        [Required]
        [DisplayName("الحالة الزوجية")]
        public MarriedStatus MarriedStatus { get; set; }
        [Required]
        [DisplayName("محل الاقامة")]
        public string? MahalAkama { get; set; }
        [Required]
        [DisplayName("المحافظة")]
        public string? DohPaName { get; set; }
        [Required]
        [DisplayName("القضاء")]
        public string? kADAPa { get; set; }
        [Required]
        [DisplayName("الناحية")]
        public string? NahiaPa { get; set; }
        [DisplayName("رقم الصحيفة")]
        public int SahifaNum { get; set; }
        [DisplayName("رقم السجل")]
        public int SajilNum { get; set; }
        [DisplayName("دائرة الاحوال")]
        public String? AhwalName { get; set; }
        [DisplayName(" البطاقة الموحدة")]
        public string? Mwhada { get; set; }
        [Required]
        [DisplayName("الجنسية ")]
        public NationNamw NationNamw { get; set; }
        [Required]
        [DisplayName("تاريخ الدخول ")]
        public DateTime DateIn { get; set; } = DateTime.Now;
        [DisplayName("جهة الاحالة ")]
        public Reffer Reffer { get; set; }
        [Required]
        [DisplayName(" سبب دخول المريض ")]
        public string? PatientIn { get; set; }
        [Required]
        [DisplayName(" مدحن ام لا؟ ")]
        public string? PatientSmoke { get; set; }
        [Required]
        [DisplayName(" مصاب بداء السكر؟ ")]
        public string? PatientDibetes { get; set; }
        [Required]
        [DisplayName(" مصاب بارتفاع ضغط الدم؟ ")]
        public string? PatientHypertenssion { get; set; }
        [Required]
        [DisplayName(" وزن المريض ")]
        public int PatientWeight { get; set; }
        [Required]
        [DisplayName(" تاريخ الخروج ")]
        public DateTime DateOut { get; set; } = DateTime.Now;
        [Required]
        [DisplayName(" التسخيص النهائي للمرض ")]
        public string? DiagIcd10 { get; set; }
        [DisplayName(" تاريخ اجراء العملية ")]
        public DateTime DateSurgery { get; set; } = DateTime.Now;
        [DisplayName(" نوع العملية ")]
        public string? TypeSurgeryName { get; set; }
        [DisplayName(" درجتها ")]
        public string? DegreeSurgeryName { get; set; } 
        [Required]
        [DisplayName(" حالة المريض عند الخروج ")]
        public string? StatePatientOut { get; set; }
        [DisplayName(" مجموع الرقودات السابقة للمريض خلال السنة بهذه المستشفى ")]
        public int NumPatientVisit { get; set; } = 0;
        [Required]
        [DisplayName(" اسم الطبيب  ")]
        public string? DoctorName { get; set; }
        [Required]
        [DisplayName(" الشهادة  ")]
        public string? Certificate { get; set; }
        [Required]
        [DisplayName(" اختصاص الطبيب")]
        public string? DoctorSpe { get; set; }
    }
   
}
