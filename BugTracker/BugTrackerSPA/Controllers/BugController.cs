using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataLayer;

namespace BugTrackerSPA.Controllers
{
    public class BugController : ApiController
    {
        private DataLayerContext db = null;
        public BugController()
        {
            db = new DataLayerContext();
        }

        [HttpGet]
        public IEnumerable<Bug> AllBugs()
        {
            var bug = db.Bug.ToList();
            return bug;
        }
    }
}
