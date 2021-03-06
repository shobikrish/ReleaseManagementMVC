using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReleaseManagementMVC.Models;

namespace ReleaseManagementMVC.Controllers
{
    
    public class RegisterController : Controller
    {
        ReleaseManagementContext dbcontext = new ReleaseManagementContext();
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult reg()
        {
            return View();
        }

        [HttpPost]
        public ActionResult reg(Login login)
        {
            dbcontext.Logins.Add(login);
            dbcontext.SaveChanges();

            return View();
        }
    }
}