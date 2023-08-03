using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using WantSoraCoreMVC.Models;
using JsonSerializer = System.Text.Json.JsonSerializer;


namespace WantSoraCoreMVC.Controllers
{
    public class ForumController : Controller
    {
        private readonly IMemoryCache _memoryCache;
        public ForumController(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        int loginID = 56;//先綁死ID登入
        NewIspanProjectContext db = new NewIspanProjectContext();

        // GET: Forum
        public IActionResult CategoryList()
        {
            IEnumerable<ForumCategory> datas = from f in db.ForumCategories
                                               select f;
            return View(datas);
        }

        public IActionResult PostList(int? categoryId, string OrderBy, string q)
        {


            if (categoryId == null)
                return RedirectToAction("CategoryList");

            var posts = from p in db.ForumPosts
                        .Include(p => p.ForumPostCategories).ThenInclude(pc => pc.Category)
                        .Include(p => p.Account)
                        .Include(p => p.ForumPostComments).ThenInclude(c => c.StatusNavigation)
                        .Include(p => p.ForumPostComments).ThenInclude(c => c.Account)
                        where p.ForumPostCategories.FirstOrDefault().CategoryId == categoryId
                        where p.Status == 1 || p.Status == 4
                        select p;


            if (!string.IsNullOrEmpty(q))
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

            ViewBag.CategoryId = categoryId;
            return View(posts);
        }

        public IActionResult PostView(int? postID)
        {
            if (postID == null)
                return RedirectToAction("PostList");

            var post = db.ForumPosts
                        .Include(p => p.ForumPostCategories).ThenInclude(pc => pc.Category)
                        .Include(p => p.Account)
                        .Include(p => p.ForumPostComments).ThenInclude(c => c.StatusNavigation)
                        .Include(p => p.ForumPostComments).ThenInclude(c => c.Account)
                        .FirstOrDefault(p => p.PostId == (int)postID);

            //-----------------------觀看次數-----------------------------
            int viewCount = 0;
            //建立MemoryCache，先確定是否有某篇文章的KEY存在
            if (_memoryCache.TryGetValue("ViewCount_" + postID,out viewCount))
            {
                viewCount = (int)_memoryCache.Get("ViewCount_" + postID);//有的話就抓key對應的value
            }
            else
            {
                // 如果沒有這個key從資料庫中取得觀看次數
                viewCount = (post.ViewCount.HasValue) ? post.ViewCount.Value : 0;

                viewCount++;
                post.ViewCount = viewCount;
                db.SaveChanges();
                // 將觀看次數存入快取，設定快取時間，例如 1 小時
                var cacheEntryOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = DateTime.Now.AddHours(1)
                };
                _memoryCache.Set("ViewCount_" + postID, viewCount, cacheEntryOptions);
            }

            return View(post);
        }

        public IActionResult CreatePost(int? categoryId)
        {
            if (categoryId == null)
                return RedirectToAction("CategoryList");
            return View();
        }
        [HttpPost]
        public IActionResult CreatePost(ForumPost post)
        {
            ForumPost x = new ForumPost();
            x.AccountId = loginID;
            x.Title = post.Title;
            x.PostContent = post.PostContent;
            x.Created = DateTime.Now;
            x.Status = 1;
            x.ViewCount = 0;
            db.ForumPosts.Add(x);
            db.SaveChanges();

            int categoryId = 0;
            int.TryParse(Request.Query["categoryId"], out categoryId);

            ForumPostCategory category = new ForumPostCategory();
            category.PostId = x.PostId;
            category.CategoryId = categoryId;
            db.ForumPostCategories.Add(category);
            db.SaveChanges();
            return RedirectToAction("PostList", new { categoryId = categoryId });
        }

    }
}
