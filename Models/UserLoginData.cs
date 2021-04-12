using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BTB_Project.Models
{
    public class UserLoginData
    {
        [Key]
        [Required(ErrorMessage = "יש להזין תעודת זהות")]
        [StringLength(50, MinimumLength = 1)]
        public string Id { get; set; }

        [Required(ErrorMessage = "יש להזין סיסמא")]
        [StringLength(50, MinimumLength = 1)]
        public string Password { get; set; }
    }
}