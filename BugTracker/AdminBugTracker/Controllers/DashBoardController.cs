using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace AdminBugTracker.Controllers
{
    public class DashBoardController : Controller
    {
        //
        // GET: /DashBoard/
        DataLayerContext db = null;
        public DashBoardController()
        {
            db = new DataLayerContext();
        }

        public ActionResult Index()
        {
            ViewBag.bugs = db.Bug.Where(m => m.statusId == 8 || m.statusId == 9 || m.deadLine <= DateTime.Today).AsEnumerable();

            return View();
        }

    }
}
