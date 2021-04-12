using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BTB_Project.Models
{
    [Table("Accounts")]
    public class Account
    {
        [Key]
        public string AccountId { get; set; }
        public string Branch { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public virtual User User { get; set; }

        public string Bank { get; set; }

        
    }
}