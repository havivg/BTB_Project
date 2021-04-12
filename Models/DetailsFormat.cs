using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BTB_Project.Models
{
    public class DetailsFormat
    {
        [Required(ErrorMessage = "יש להזין שם משפחה")]
        public string FamilyName { get; set; }
        [Required(ErrorMessage = "יש להזין תאריך לידה")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DateOfBirth { get; set; }
        [Required(ErrorMessage = "יש להזין אימייל")]

        public string Email { get; set; }
        [Required(ErrorMessage = "יש להזין את מספר החברה")]
        public string CompanyNumber { get; set; }
        [Required(ErrorMessage = "יש להזין שם פרטי")]
        public string FirstName { get; set; }

        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "יש להזין את שם החברה")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "יש להזין תעודת זהות")]
        public string Id { get; set; }
    }
}