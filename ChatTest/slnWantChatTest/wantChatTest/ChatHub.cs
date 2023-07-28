using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wantChatTest
{
    public class ChatHub : Hub
    {
        public void Send(string name, string message)
        {
            //這裡的addNewMessageToPage是VIEW的JS方法
            Clients.All.addNewMessageToPage(name, message);
    }
}