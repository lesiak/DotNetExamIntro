using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;

namespace BroadcasterService
{
    public class Broadcaster : Hub
    {
        public Task Broadcast(string message)
        {
            return Clients.All.Message("[Broadcast] " + message);
        }
        public override Task OnConnected()
        {
            return
                ((Task) Clients.Caller.Message("Greetings from a windows service"))
                    .ContinueWith(_=> Clients.All.Message("[Broadcast] New client arrived"));
        }

        public override Task OnDisconnected(bool stopCalled) {
            return Clients.All.Message("[Broadcast] Client disconnected");
        }
    
    }
}
