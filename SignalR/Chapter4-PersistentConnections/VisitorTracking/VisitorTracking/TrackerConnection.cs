﻿using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;

namespace VisitorTracking {
    public class TrackerConnection : PersistentConnection {
        protected override Task OnReceived(IRequest request, string connectionId, string data) {
            return Connection.Broadcast(data);
        }
    }
}