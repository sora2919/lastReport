using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace wantSora.Controllers
{
    public class ForumController : Controller
    {
        // GET: Forum
        public ActionResult List()
        {
            NewIspanProjectEntities db = new NewIspanProjectEntities();
            var datas = from f in db.ForumCategory
                        select f;
            return View(datas);
        }


    }
}