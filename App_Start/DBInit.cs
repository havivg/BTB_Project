using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BTB_Project.Models;
using BTB_Project.Controllers;
namespace BTB_Project.App_Start
{
    public class DBInit:System.Data.Entity.DropCreateDatabaseAlways<DB_Entities>
    {
        //initial the db with 4 users
        protected override void Seed(DB_Entities context)
        {
            context.Users.Add(new User { Id = "11111111", FirstName = "א", FamilyName = "ישראלי", Email = "1@gmail.com", Password = HomeController.GetMD5("11111111") });
            context.Users.Add(new User { Id = "22222222", FirstName = "ב", FamilyName = "ישראלי", Email = "2@gmail.com", Password = HomeController.GetMD5("22222222") });
            context.Users.Add(new User { Id = "33333333", FirstName = "ג", FamilyName = "ישראלי", Email = "3@gmail.com", Password = HomeController.GetMD5("33333333") });
            context.Users.Add(new User { Id = "44444444", FirstName = "ד", FamilyName = "ישראלי", Email = "4@gmail.com", Password = HomeController.GetMD5("44444444") });
        }
    }
}