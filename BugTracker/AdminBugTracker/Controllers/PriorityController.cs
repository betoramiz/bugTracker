using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace AdminBugTracker.Controllers
{
    public class PriorityController : Controller
    {
        private DataLayerContext db = null;

        public PriorityController()
        {
            db = new DataLayerContext();
        }

        public ActionResult Index()
        {
            try
            {
                var priority = db.Priority.ToList();
                if(priority.Count > 0)
                    return View(priority);
                else{
                    ViewBag.errorMessage = "There are no priority in the database, Add a new Priority";
                    return View();
                }
                    
            }
            catch(Exception ex)
            {
                string mesaage = ex.InnerException.Message;
                ViewBag.errorMessage = "An error ocurred when at displayed the priorities list";
                return View();
            }
        }

        public ActionResult Add()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Add(Priority priority)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    db.Priority.Add(priority);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.errorMessage = "An error ocurred while try to add a Priority";
                    return View();
                }
            }
            catch(Exception ex)
            {
                string message = ex.InnerException.Message;
                ViewBag.errorMessage = "An error ocurred while try to add a Priority. Check log for details";
                return View();
            }
        }


        public ActionResult Update(int id)
        {
            try
            {
                Priority priority = db.Priority.Find(id);
                if (priority == null)
                {
                    ViewBag.errorMessage = "There is no a priority with Id " + id.ToString();
                    return View();
                }
                else
                    return View(priority);
            }
            catch(Exception ex)
            {
                string message = ex.InnerException.Message;
                ViewBag.errorMessage = "someting went wrong. Check log for details";
                return View();
            }
        }

        [HttpPost]
        public ActionResult Update(Priority priority)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    db.Entry(priority).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.errorMessage = "Something went wrong when ty to update the priority";
                    return View();
                }
            }
            catch(Exception ex)
            {
                string message = ex.InnerException.Message;
                ViewBag.errorMessage = "Something went wrong when ty to update the priority, Check log for details";
                return View();
            }
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            try
            {
                Priority priority = db.Priority.Find(id);
                if (priority == null)
                    return Json("fail");
                else
                {
                    db.Priority.Remove(priority);
                    db.SaveChanges();
                    return Json("success");
                }
            }
            catch(Exception ex)
            {
                string message = ex.InnerException.Message;
                return Json("fail");
            }
        }
    }
}
