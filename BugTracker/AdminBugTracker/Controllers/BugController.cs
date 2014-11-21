using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace AdminBugTracker.Controllers
{
    public class BugController : Controller
    {
        private DataLayerContext db = null;

        public BugController()
        {
            db = new DataLayerContext();
        }

        public ActionResult Index()
        {
            try
            {
                var bug = db.Bug.ToList();
                if(bug.Count > 0)
                {
                    return View(bug);
                }
                else
                {
                    ViewBag.errorMessage = "There is no bugs. Add one";
                    return View();
                }
            }
            catch(Exception ex)
            {
                string message = ex.Message;
                ViewBag.errorMessage = "There was an error, check log";
                return View();
            }
        }

        public ActionResult Add()
        {
            ViewModels.BugViewModel bugVM = new ViewModels.BugViewModel();
            bugVM.userList = db.User.ToList();
            bugVM.projectList = db.Project.ToList();
            bugVM.statusList = db.Status.ToList();
            bugVM.priorityList = db.Priority.ToList();
            bugVM.deadLine = DateTime.Today;
            if (bugVM.userList.Count == 0 || bugVM.projectList.Count == 0 || bugVM.statusList.Count == 0)
                ViewBag.errorMessage = "May ";

            return View(bugVM);
        }

        [HttpPost]
        public ActionResult Add(AdminBugTracker.ViewModels.BugViewModel bugVM)
        {
            try
            {
                Bug bug = new Bug()
                {
                    id = 0,
                    name = bugVM.name,
                    description = bugVM.description,
                    statusId = bugVM.statusId,
                    userId = bugVM.useId,
                    projectId = bugVM.projectId,
                    priorityId = bugVM.priorityId,
                    deadLine = bugVM.deadLine
                };

                if(ModelState.IsValid)
                {
                    db.Bug.Add(bug);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    bugVM.userList = db.User.ToList();
                    bugVM.projectList = db.Project.ToList();
                    bugVM.statusList = db.Status.ToList();
                    bugVM.priorityList = db.Priority.ToList();
                    return View(bugVM);
                }
                
                
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        public ActionResult Update(int id = 0)
        {
            Bug bug = db.Bug.Find(id);
            if (bug != null)
            {
                ViewModels.BugViewModel bugVM = new ViewModels.BugViewModel()
                {
                    idBug = bug.id,
                    name = bug.name,
                    description = bug.description,
                    useId = bug.userId,
                    projectId = bug.projectId,
                    statusId = bug.statusId,
                    priorityId = bug.priorityId,
                    deadLine = bug.deadLine,
                    userList = db.User.ToList(),
                    projectList = db.Project.ToList(),
                    priorityList = db.Priority.ToList(),
                    statusList = db.Status.ToList()
                };
                return View(bugVM);
            }
            else
                return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Update(AdminBugTracker.ViewModels.BugViewModel bugVM)
        {
            try
            {
                Bug bug = db.Bug.Find(bugVM.idBug);
                bug.name = bugVM.name;
                bug.description = bugVM.description;
                bug.statusId = bugVM.statusId;
                bug.userId = bugVM.useId;
                bug.projectId = bugVM.projectId;
                bug.priorityId = bugVM.priorityId;
                bug.deadLine = bugVM.deadLine;

                if (ModelState.IsValid)
                {
                    db.Entry(bug).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    bugVM.userList = db.User.ToList();
                    bugVM.projectList = db.Project.ToList();
                    bugVM.statusList = db.Status.ToList();
                    bugVM.priorityList = db.Priority.ToList();
                    return View(bugVM);
                }
                return View();
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            try
            {
                Bug bug = db.Bug.Find(id);
                db.Bug.Remove(bug);
                db.SaveChanges();
                return Json("success");
            }
            catch(Exception ex)
            {
                return Json("fail");
            }
        }
    }
}
