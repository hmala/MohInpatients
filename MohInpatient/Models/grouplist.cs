using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MohInpatient.Models
{
    public class grouplist
    {
        public enum Gender
        {
            [Display(Name = "ذكر")]

            male = 1,
            [Display(Name = "أنثى")]

            female = 2
        }
        public enum Education
        {
            [Display(Name="دكتوراه")]
            doctor = 1,
            [Display(Name = "ماجستير")]
            master = 2,
            [Display(Name = "بكالوريوس")]

            Bacheloris = 4,
            [Display(Name = "دبلوم")]

            diploma = 5,
            [Display(Name = "اعدادية")]

            highschool = 6,
            [Display(Name = "متوسطة")]

            midschool = 7,
            [Display(Name = "أبتدائية")]

            primaryschool = 8,
            [Display(Name = "يقرا ويكتب")]


            readwrite = 9,
            [Display(Name = "أمي")]

            mom = 10,

        }
        public enum job
        {
            [Display(Name = "طبيب")]
            doctor = 1,
            [Display(Name = "طبيب اسنان")]
            dentist = 2,
            [Display(Name = "صيدلي")]

            pharm = 3,
            [Display(Name = "مهندس")]

            engenerring = 4,
            [Display(Name = "ممرض")]

            nurse = 5,
            [Display(Name = "معلم")]

            Teacher = 6,
            [Display(Name = "مدرس")]

            Teacher1 = 7,
            [Display(Name = "موظف")]

            employee = 8,
            [Display(Name = "متقاعد")]

            retired = 9,
            [Display(Name = "طالب")]

            student = 10,
            [Display(Name = "طفل")]

            child = 11,
            [Display(Name = "عاجز")]

            helpless = 12,
            [Display(Name = "فلاح")]

            peasant = 13,
            [Display(Name = "عامل")]

            worker = 14,
            [Display(Name = "ربة بيت")]

            Housewife = 15,
            [Display(Name = "مهن اخرى")]

            others = 16,
            [Display(Name = "سجين")]

            prisoner= 17,
            [Display(Name = "عسكري")]

            military = 18,
            [Display(Name = "حشد شعبي")]

            submilirty = 19
        }
        public enum MarriedStatus
        {
            [Display(Name = "أعزب")]
            single = 1,
            [Display(Name = "متزوج")]
            married = 2,
            [Display(Name = "أرملة")]
            widow = 3,
            [Display(Name = "مطلقة")]
            divorsed = 4,
       
        }
        
             public enum MahalAkama
        {
            [Display(Name = "حضر")]

            civilizedregion = 1,
            [Display(Name = "ريف")]

            countryside = 2,
        }
        public enum NationNamw
        {
            [Display(Name = "عراقي")]

            iraqi = 1,
            [Display(Name = "عربي")]

            arabic = 2,
            [Display(Name = "اجنبي")]

            foreign = 3,
            [Display(Name = "اخرى")]

            others = 4,
        }
        public enum Reffer
        {
            [Display(Name = "استشارية")]

            consultant = 1,
            [Display(Name = "طوارئ")]

            emergency = 2,
            [Display(Name = "عيادة خاصة")]

            Privateclinic = 3,
            [Display(Name = "مستشفى اخرى")]

            otherhospital = 4,
            [Display(Name = "اخرى")]

            others = 5,
        }
        public enum PatientSmoke
        {
            yes = 1,
            no = 2,
        }
        public enum PatientDibetes
        {
            yes = 1,
            no = 2,
        }
        public enum PatientHypertenssion
        {
            yes = 1,
            no = 2,

        }
    }
}

    
    