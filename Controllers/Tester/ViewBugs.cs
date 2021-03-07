using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReleaseManagementMVC.Controllers
{
    public partial class TesterController : Controller
    {
        
        public ActionResult ViewBugs(string id)
        {
            var data = testContext.Bugs.Where(b=>b.TesterID.Equals(id));
            return View(data);
        }
    }
}