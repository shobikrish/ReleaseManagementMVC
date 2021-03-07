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

        public ActionResult RaiseBug(string id)
        {
            try
            {
                var moduleIdsFromDB = from x in testContext.Modules select x.ModuleID;
                ViewBag.moduleIds = new SelectList(moduleIdsFromDB.ToList(), "ModuleID");
                if (moduleIdsFromDB == null)
                {
                    ViewBag.ErrorMessage = "No Modules Found !!!";
                }

                ViewBag.TesterID = id;
               
                //var testerIdsFromDB = from x in testContext.Testers select x.TesterID;
                //ViewBag.testerIds = new SelectList(testerIdsFromDB.ToList(), "TesterID");

                //if (testerIdsFromDB == null)
                //{
                //    ViewBag.ErrorMessage = "No Modules Found !!!";
                //}
               
            }
            catch(Exception e)
            {
                ViewBag.ErrorMessage = "Raising Bug Failed : " +  e.Message;
            }

            return View();
        }

        [HttpPost]
        public ActionResult RaiseBug(String id  , Bug bug)
        {
            try
            {
                bug.TesterID = id;
                bug.BugStatus = "Open";
                testContext.Bugs.Add(bug);
                testContext.SaveChanges();
            }
            catch
            {
                ViewData["msg"] = "RaiseBugFailedMessage";
                return View("FailedMessage");
            }

            ViewData["msg"] = "RaiseBugSuccessMessage";
            return View("SuccessMessage");
        }


    }
}