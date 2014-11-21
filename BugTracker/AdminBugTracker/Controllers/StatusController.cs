using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace AdminBugTracker.Controllers
{
    public class StatusController : Controller
    {
        private DataLayer.DataLayerContext db = null;

        public StatusController()
        {
            db = new DataLayerContext();
        }
        public ActionResult Index()
        {
            try
            {
                var status = db.Status.ToList();
                if(status.Count == 0)
                    ViewBag.Message = "There are no Status for display. Add a new Status";
                return View(status);
            }
            catch(Exception ex)
            {
                string errorMessage = ex.Message;
                //add to log
                return View();
            }
            
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Status status)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    db.Status.Add(status);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                    return View();
            }
            catch(Exception ex)
            {
                string messageError = ex.InnerException.Message;
                return View();
            }
        }

        public ActionResult Update(int id)
        {
            try
            {
                Status status = db.Status.Find(id);
                if (status == null)
                {
                    ViewBag.Message = "The status requested not exist";
                    return View();
                }
                else
                    return View(status);
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Update(Status status)
        {
            try
            {
                db.Entry(status).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            try
            {
                Status status = db.Status.Find(id);
                db.Status.Remove(status);
                db.SaveChanges();
                return Json("success");
            }
            catch(Exception ex)
            {
                return Json("fail");
            }
        }

        public ActionResult Error()
        {
            return View();
        }
    }
}
