using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReleaseManagementMVC.Models;

namespace ReleaseManagementMVC.Controllers
{
    public partial class TesterController : Controller
    {
        ReleaseManagementContext testContext = new ReleaseManagementContext();
        // GET: Tester
        public ActionResult Index()
        {
            string id = TempData.Peek("UserID").ToString();
            Tester tester = testContext.Testers.FirstOrDefault(x => x.TesterID.Equals(id));
            ViewData["EmpName"] = tester.TesterName;
            ViewData["UserID"] = id;
            return View();
        }

        
    }
}