using Microsoft.AspNetCore.Mvc;

namespace WantSoraCoreMVC.Controllers
{
    public class ChatController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
