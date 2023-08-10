using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WantSoraCoreMVC.Models;

namespace WantSoraCoreMVC.Controllers
{
    public class ChatApiController : Controller
    {

        int loginID = 56;//先綁死ID登入
        NewIspanProjectContext db = new NewIspanProjectContext();


        public IActionResult UserList()
        {
            var orderMessages = db.ChatMessages
                                .OrderByDescending(m => m.Created) // 按照時間戳排序，最新的在前面
                                .ToList();

            var users= orderMessages
                      .Where(m=>m.SenderId== loginID||m.ReceiverId==loginID)
                      .OrderByDescending(m => m.Created)
                      .Select(m=>m.SenderId==loginID?m.ReceiverId:m.SenderId)
                      .Distinct().ToList();

            //JOIN參考資料 https://ithelp.ithome.com.tw/articles/10196394?sc=iThelpR
            var usersInfo = users
                .Join(db.MemberAccounts, a => a, member => member.AccountId, (userId, member) => member)
                .Select(u => new
                {
                    u.Name,
                    u.UserName,
                    u.MemberPhoto
                })
                .ToList();

            return Json(usersInfo);
        }
    }
}
