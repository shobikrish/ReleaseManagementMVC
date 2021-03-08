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

            List<SelectListItem> bugStatusStates = new List<SelectListItem>() { };
            bugStatusStates.Add(new SelectListItem() { Text = "Reopen", Value = "Reopen" });
            bugStatusStates.Add(new SelectListItem() { Text = "Closed", Value = "Closed" });
            
            ViewBag.BugStatuses = bugStatusStates;

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

                ViewData["msg"] = "BugStatusSuccessMessage";
                return View("SuccessMessage");
            }
            else
                ViewData["msg"] = "BugStatusFailedMessage";
                return View("FailedMessage");

        }


        public ViewResult Delete(string id)
        {
            var data = testContext.Bugs.FirstOrDefault(x => x.BugID.Equals(id));
            return View(data);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id)
        {

            var data = testContext.Bugs.FirstOrDefault(x => x.BugID.Equals(id));
            if (data != null)
            {
                testContext.Bugs.Remove(data);
                testContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return View();
        }



    }
}