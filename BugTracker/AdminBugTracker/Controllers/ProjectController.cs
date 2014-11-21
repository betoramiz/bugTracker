using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace AdminBugTracker.Controllers
{
    public class ProjectController : Controller
    {
        private DataLayerContext db = null;
        public ProjectController()
        {
            db = new DataLayerContext();
        }

        public ActionResult Index()
        {
            try
            {
                var projects = db.Project.ToList();
                if(projects.Count == 0)
                {
                    ViewBag.errorMessage = "There is no Project in the Database. Add One";
                    return View();
                }
                else
                    return View(projects);
            }
            catch(Exception ex)
            {
                return View();
            }
            
        }
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Project project)
        {
            try
            {
                db.Project.Add(project);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        public ActionResult Update(int id = 0)
        {
            try
            {
                Project project = db.Project.Find(id);
                if(id==0)
                {
                    ViewBag.errorMessage = "There is no project with id " + id.ToString();
                    return View();
                }
                else
                {
                    if (project == null)
                    {
                        ViewBag.errorMessage = "There is no project with id " + id.ToString();
                        return View();
                    }
                    else
                        return View(project);
                }
            }
            catch(Exception ex)
            {
                string message = ex.InnerException.Message;
                ViewBag.errorMessage = "Something went wrong whe try to update the register, try Again later";
                return View();
            }
        }

        [HttpPost]
        public ActionResult Update(Project project)
        {
            try
            {
                db.Entry(project).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
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
                Project project = db.Project.Find(id);
                db.Project.Remove(project);
                db.SaveChanges();
                return Json("success");
            }
            catch
            {
                return Json("fail");
            }
        }
    }
}
