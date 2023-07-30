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
        NewIspanProjectEntities db = new NewIspanProjectEntities();

        // GET: Forum
        public ActionResult CategoryList()
        {
            IEnumerable<ForumCategory> datas = from f in db.ForumCategory
                                               select f;
            return View(datas);
        }

        public ActionResult PostList(int categoryId)
        {
            var posts = from p in db.ForumPost
                        where p.ForumPostCategory.FirstOrDefault().CategoryID == categoryId
                        where p.Status==1||p.Status==4
                        select p;

            return View(posts);
        }


    }
}