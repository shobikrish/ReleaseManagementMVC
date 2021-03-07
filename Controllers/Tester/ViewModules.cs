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

        public ActionResult ViewModules(string id)
        {
            var data = testContext.Modules.Where(m=>m.TesterID == id) ;
            return View(data);
        }
    }
}