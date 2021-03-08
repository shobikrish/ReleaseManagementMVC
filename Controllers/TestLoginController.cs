using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReleaseManagementMVC.Models;

namespace ReleaseManagementMVC.Controllers
{
    public class TestLoginController : Controller
    {
        ReleaseManagementContext context = new ReleaseManagementContext();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Login login)
        {
            var data = context.Logins.FirstOrDefault(x => x.LoginID == login.LoginID);

            if (data != null)
            {

                if (data.Password == login.Password)
                {
                    TempData["UserID"] = data.LoginID;
                    return RedirectToAction("Index", "Tester");
                }
                else
                {
                    ViewBag.ErrorMessage = "User ID or Password Incorrect";
                    return View();
                }

            }
            else
            {
                ViewBag.ErrorMessage = "Login Failed";
                return View();
            }
        }

    }
}