using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace AdminBugTracker.Controllers
{
    public class RoleController : Controller
    {
        private DataLayerContext db = null;

        public RoleController()
        {
            db = new DataLayerContext();
        }

        public ActionResult Index()
        {
            try
            {
                var roles = db.Role.ToList();
                return View(roles);
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
        public ActionResult Add(Role role)
        {
            try
            {
                db.Role.Add(role);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        public ActionResult Update(int id)
        {
            try
            {
                Role role = db.Role.Find(id);
                return View(role);
            }
            catch(Exception ex)
            {
                return View();
            }
        }


        [HttpPost]
        public ActionResult Update(Role role)
        {
            try
            {
                db.Entry(role).State = System.Data.Entity.EntityState.Modified;
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
                Role role = db.Role.Find(id);
                db.Role.Remove(role);
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
