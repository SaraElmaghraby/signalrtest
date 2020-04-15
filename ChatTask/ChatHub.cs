using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace ChatTask
{
    [HubName("chathub")]
    public class ChatHub : Hub
    {
        //public void Hello()
        //{
        //    Clients.All.hello();
        //}
        public void send(string name, string message)
        {
            Clients.All.newMessage(name, message);
        }
        public void joinGroup(string groupname, string name)
        {
            Groups.Add(Context.ConnectionId, groupname);
            Clients.OthersInGroup(groupname).newMember(name);
        }

        public void sendGroup(string name, string groupName, string message)
        {
            Clients.Group(groupName).newGroupMess(name, groupName, message);
        }
    }
}