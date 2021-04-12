using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BTB_Project.Models;
using System.Security.Cryptography;
using System.Text;
namespace BTB_Project.Controllers
{

    public class HomeController : Controller
    {
        private DB_Entities _db = new DB_Entities();
        
        
        public ActionResult Index()
        {
            return View();
        }

        //GET: ACCOUNTS
        public ActionResult Accounts()
        {
            string sessionId = (string)Session["id"];
            var user = _db.Users.Where(s => s.Id.Equals(sessionId)).FirstOrDefault<User>();
            return View(user);
        }


        //POST: ACCOUNTS
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        /*  received user accounts details
         *  add user accounts to db .
         */
        public ActionResult Accounts(String any="")
        {
            
            
            if (ModelState.IsValid)
            {
                string sessionId = (string)Session["id"];
                if (sessionId != null)
                {
                    var user = _db.Users.Where(s => s.Id.Equals(sessionId)).FirstOrDefault<User>();
                    var n = (Request.Form.Count-4) / 3;
                    //Loop through the forms
                    try
                    {
                        int i = 0;
                        int counter = 0;
                        while (counter<n)
                        {
                            if(Request.Form["Banks[" + i + "]"] != null)
                            {
                                var bank = Request.Form["Banks[" + i + "]"];
                                var branch = Request.Form["Branches[" + i + "]"];
                                var accountId = Request.Form["AccountsId[" + i + "]"];

                                user.Accounts.Add(new Account { Bank = bank, Branch = branch, AccountId = accountId });
                                counter++;
                            }
                            i++;

                        }
                        
                        user.HoldingPercentage = Int32.Parse(Request.Form["Holding"]);
                        _db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    catch (Exception)
                    {
                        TempData["Message"] = "מספר החשבון צריך להיות יחודי";
                        return RedirectToAction("Accounts");
                    }
                }
                else
                {
                    return RedirectToAction("Login");
                }

            }
            
            
            return View();
        }

        //GET: DETAILS
        public ActionResult Details()
        {
            string sessionId = (string)Session["id"];
            var user = _db.Users.Where(s => s.Id.Equals(sessionId)).FirstOrDefault<User>();
            return View(user);
        }

        //POST: Details
        [HttpPost]
        [ValidateAntiForgeryToken]
        /*  received user details data
         *  update user details on db and returns the next view.
         */
        public ActionResult Details(DetailsFormat _user)
        {

            if (ModelState.IsValid)
            {
                string sessionId = (string)Session["id"];
                if (sessionId != null)
                {
                    //bring user object from db
                    var user = _db.Users.Where(s => s.Id.Equals(sessionId)).FirstOrDefault<User>();
                    //check if user update his details, and change necessary
                    if (user.FirstName == null || !user.FirstName.Equals(_user.FirstName)) { user.FirstName = _user.FirstName; }
                    if (user.FamilyName == null || !user.FamilyName.Equals(_user.FamilyName)) { user.FamilyName = _user.FamilyName; }
                    if (user.Email == null || !user.Email.Equals(_user.Email)) { user.Email = _user.Email; }
                    if (user.PhoneNumber == null || !user.PhoneNumber.Equals(_user.PhoneNumber)) { user.PhoneNumber = _user.PhoneNumber; }
                    if (user.DateOfBirth == null || !user.DateOfBirth.Equals(_user.DateOfBirth)) { user.DateOfBirth = _user.DateOfBirth; }
                    if (user.CompanyName == null || !user.CompanyName.Equals(_user.CompanyName)) { user.CompanyName = _user.CompanyName; }
                    if (user.CompanyNumber == null || !user.CompanyNumber.Equals(_user.CompanyNumber)) { user.CompanyNumber = _user.CompanyNumber; }

                    _db.SaveChanges();

                    return RedirectToAction("Accounts");
                }
                else
                {
                    return RedirectToAction("Login");
                }

            }
            return View();
        }

        //GET: LOGIN
        public ActionResult Login()
        {   
            return View();
        }

        //POST: LOGIN
        [HttpPost]
        [ValidateAntiForgeryToken]
        /*  received user login data(id and password) 
         *  if details are correct returns the next view, else display error message.
         */
        public ActionResult Login(UserLoginData userLoginData)
        {
            if (ModelState.IsValid)
            {
                var f_password = GetMD5(userLoginData.Password);
                //check if user exists in db, and bring him
                var data = _db.Users.Where(s => s.Id.Equals(userLoginData.Id) && s.Password.Equals(f_password)).ToList();
                //check if user exists
                if (data.Count() > 0)
                {
                    //update user last login
                    data.SingleOrDefault().LastLoginDate = DateTime.Now;
                    _db.SaveChanges();
                    //add session
                    Session["FullName"] = data.FirstOrDefault().FirstName + " " + data.FirstOrDefault().FamilyName;
                    Session["id"] = data.FirstOrDefault().Id;
                    return RedirectToAction("Details");
                }
                else
                {

                    TempData["Message"] = "תעודת זהות או סיסמא שגויים";
                    return RedirectToAction("Login");
                }
            }
            return View();
        }

        //create a string MD5 for passwords
        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }
    }
}