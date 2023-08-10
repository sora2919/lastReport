using Microsoft.AspNetCore.Mvc;
using WantSoraCoreMVC.Models;

namespace WantSoraCoreMVC.Controllers
{
    public class ChatController : Controller
    {
        int loginID = 56;//先綁死ID登入
        NewIspanProjectContext db = new NewIspanProjectContext();

        public IActionResult Index()
        {
            return View();
        }

    }
}
