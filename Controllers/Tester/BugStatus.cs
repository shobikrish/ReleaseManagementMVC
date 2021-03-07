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

        // GET: BugStatus
        public ActionResult BugStatus(string id)
        {
            var data = testContext.Bugs.Where(b =>b.TesterID==id);
            return View(data);
        }

        public ActionResult Edit(string bugId)
        {
            ViewBag.BugID = bugId;
            var data = testContext.Bugs.Where(x => x.BugID.Equals(bugId)).SingleOrDefault();
            
            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(string id,Bug  model)
        {
            var data = testContext.Bugs.FirstOrDefault(x => x.BugID == id);

            if (data != null)
            {

                data.BugStatus = model.BugStatus;
                
                testContext.SaveChanges();

                return RedirectToAction("SuccessMessage");
            }
            else
                return View();

        }


    }
}