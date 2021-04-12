using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTB_Project.Models
{
    [Table("Users")]
    public class User
    {
        
        public User()
        {
            Accounts = new List<Account>();
        }
        
        
        [Key]
        [Required(ErrorMessage = "יש להזין תעודת זהות")]
        [StringLength(50, MinimumLength = 1)]
        public string Id { get; set; }

        
        public string FirstName { get; set; }
        //[StringLength(50, MinimumLength = 2)]
        public string FamilyName { get; set; }

        //[RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}")]
        public string Email { get; set; }

        [Required(ErrorMessage = "יש להזין סיסמא")]
        [StringLength(50, MinimumLength = 1)]
        public string Password { get; set; }

        public string PhoneNumber { get; set; }

        [DataType(DataType.Date)]
        public Nullable<DateTime> DateOfBirth { get; set; }
        

        

        public string CompanyName { get; set; }

        public string CompanyNumber { get; set; }

        [DataType(DataType.Date)]
        public Nullable<DateTime> LastLoginDate { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }

        public int HoldingPercentage { get; set; }

        public string FullName()
        {
            return this.FirstName + " " + this.FamilyName;
        }
        
    }

}