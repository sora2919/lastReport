using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Runtime.Caching;
using System.Web;
using System.Web.Mvc;
using X.PagedList;

namespace wantSora.Controllers
{
    public class ForumController : Controller
    {
        int loginID = 56;//先綁死ID登入
        NewIspanProjectEntities db = new NewIspanProjectEntities();

        // GET: Forum
        public ActionResult CategoryList()
        {
            IEnumerable<ForumCategory> datas = from f in db.ForumCategory
                                               select f;
            return View(datas);
        }

        public ActionResult PostList(int? categoryId, string OrderBy, string q)
        {
            if (categoryId == null)
                return RedirectToAction("CategoryList");

            var posts = from p in db.ForumPost
                        where p.ForumPostCategory.FirstOrDefault().CategoryID == categoryId
                        where p.Status == 1 || p.Status == 4
                        select p;
            if(!string.IsNullOrEmpty(q))
            {
                //posts=posts.Where()
            }

            switch (OrderBy)
            {
                case "Date":
                    posts = posts.OrderBy(p => p.Created);
                    break;
                case "Date_desc":
                    posts = posts.OrderByDescending(p => p.Created);
                    break;
                // Add more cases for other sorting options if needed
                default:
                    posts = posts.OrderByDescending(p => p.Created);
                    break;
            }

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

        public ActionResult CreatePost(int? categoryId)
        {
            if (categoryId == null)
                return RedirectToAction("CategoryList");
            return View();
        }
        [HttpPost]
        public ActionResult CreatePost(ForumPost post)
        {
            ForumPost x=new ForumPost();
            x.AccountID = loginID;
            x.Title=post.Title;
            x.PostContent = post.PostContent;
            x.Created = DateTime.Now;
            x.Status = 1;
            x.ViewCount = 0;
            db.ForumPost.Add(x);
            db.SaveChanges();

            int categoryId = 0;
            int.TryParse(Request.QueryString["categoryId"], out categoryId);
            
            ForumPostCategory category = new ForumPostCategory();
            category.PostID = x.PostID;
            category.CategoryID = categoryId;
            db.ForumPostCategory.Add(category);
            db.SaveChanges();
            return RedirectToAction("PostList", new { categoryId = categoryId });
        }
    }
}