using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Owin;
using Microsoft.Owin;
[assembly: OwinStartup(typeof(wantChatTest.StartUp))]

namespace wantChatTest
{
    public class StartUp
    {
        public void Configuration(IAppBuilder app)
        {
            //好像任何連線的鬼東西都要放這邊??
            app.MapSignalR();
        }
    }
}