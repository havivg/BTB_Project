using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using BTB_Project.Models;
using BTB_Project.App_Start;
namespace BTB_Project
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            Database.SetInitializer<DB_Entities>(new DBInit());
            //Database.SetInitializer<DB_Entities>(new DropCreateDatabaseIfModelChanges<DB_Entities>());
            
        }

        

    }
}
