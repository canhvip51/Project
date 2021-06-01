using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website.Hubs
{
    public class Xmpp : Hub
    {

        public void Hello()
        {
            Clients.All.hello();
        }
        public void Send(string provinceid)
        {
            Clients.All.sendNoti(provinceid);
        }
    }
}