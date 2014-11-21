using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace AdminBugTracker.Controllers
{
    public class UserController : Controller
    {
        private DataLayerContext db;
        
        public UserController()
        {
            db = new DataLayerContext();
        }

        public ActionResult Index()
        {
            try
            {
                var users = db.User.ToList();
                if (users.Count() > 0)
                    return View(users);
                else
                {
                    ViewBag.errorMessage = "There is no user. Add one.";
                    return View();
                }
            }
            catch (Exception ex)
            {
                string message = ex.InnerException.Message;
                ViewBag.errorMessage = "An error ocurred while try to fetch register";
                return View();
            }
        }
        
        public ActionResult Add()
        {
            ViewBag.roles = new SelectList(db.Role, "id", "name", db.Role.First().id);
            return View();
        }

        [HttpPost]
        public ActionResult Add(User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.User.Add(user);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.roles = new SelectList(db.Role, "id", "name", db.Role.First().id);
                    return View(user);
                }
                
            }
            catch(Exception ex)
            {
                string message = ex.Message;
                ViewBag.errorMessage = message;
                return View();
            }
        }

        public ActionResult Update(int? id)
        {
            try
            {
                User user = db.User.Find(id);

                if (user == null)
                {
                    ViewBag.errorMessage = "There is no user with id " + id.ToString();
                    return View();
                }
                else
                {
                    ViewBag.roles = new SelectList(db.Role, "id", "name", user.role);
                    return View(user);
                }
            }
            catch(Exception ex)
            {
                string message = ex.InnerException.Message;
                ViewBag.errorMessage = "An error ocurred while try to get the user";
                return View();
            }

        }

        [HttpPost]
        public ActionResult Update(User user)
        {
            
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.roles = new SelectList(db.Role, "id", "name", db.Role.Find(user.roleId));
                    return View(user);
                }
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
                DataLayer.User user = db.User.Find(id);
                db.User.Remove(user);
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
