using WantSoraCoreMVC.Models;
using X.PagedList;

namespace WantSoraCoreMVC.ViewModels
{
    public class ForumPostListModel
    {
        public IPagedList<ForumPost> PagedPosts { get; set; }
        public int ReplyCount { get; set; } 
    }
}
