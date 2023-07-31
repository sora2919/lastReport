using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Runtime.Caching;
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

        public ActionResult PostList(int? categoryId)
        {
            if (categoryId == null)
                return RedirectToAction("CategoryList");
            var posts = from p in db.ForumPost
                        where p.ForumPostCategory.FirstOrDefault().CategoryID == categoryId
                        where p.Status==1||p.Status==4
                        orderby p.Created descending
                        select p;

            return View(posts);
        }

        public ActionResult PostView(int? postID)
        {
            if (postID == null)
                return RedirectToAction("PostList");
            var post = db.ForumPost.FirstOrDefault(p => p.PostID == (int)postID);

            //-----------------------觀看次數-----------------------------
            int viewCount = 0;
            //建立MemoryCache，先確定是否有某篇文章的KEY存在
            ObjectCache cache = MemoryCache.Default;
            if (cache.Contains("ViewCount_" + postID))
            {
                viewCount = (int)cache.Get("ViewCount_" + postID);//有的話就抓key對應的value
            }
            else
            {
                // 如果沒有這個key從資料庫中取得觀看次數
                viewCount = (post != null && post.ViewCount.HasValue) ? post.ViewCount.Value : 0;

                viewCount++;
                post.ViewCount = viewCount;
                db.SaveChanges();
                // 將觀看次數存入快取，設定快取時間，例如 1 小時
                CacheItemPolicy policy = new CacheItemPolicy();
                policy.AbsoluteExpiration = DateTime.Now.AddHours(1);
                cache.Add("ViewCount_" + postID, viewCount, policy);
            }

            return View(post);
        }
    }
}