using WantSoraCoreMVC.Models;

namespace WantSoraCoreMVC.ViewModels
{
    public class ForumPostViewModel
    {
        public ForumPost MainPost { get; set; }
        public List<ForumPost> Replies { get; set; }
        public List<ForumPostComment> Comments { get; set; }

    }
}
