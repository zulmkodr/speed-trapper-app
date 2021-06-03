using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpeedTrapperApp.SpeedTrapperHub
{
    [HubName("SpeedTrapperHub")]
    public class SpeedTrapperHub : Microsoft.AspNet.SignalR.Hub
    {
        public static int speed = 200;

        public void Send(string name, string message)
        {
            // Call the addNewMessageToPage method to update clients.
            Clients.All.addNewMessageToPage(name, message, speed);

            if (Convert.ToInt32(message) > speed)
            {

                Clients.Client(Context.ConnectionId).broadcastMessage(name, 1, message);
            }
            else { Clients.Client(Context.ConnectionId).broadcastMessage(name, 0, message); }
        }

        [HubMethodName("SetSpeed")]
        public void SetSpeed(int speed1)
        {

            speed = speed1;
        }

        public override System.Threading.Tasks.Task OnDisconnected(bool stopCalled)
        {
            return base.OnDisconnected(stopCalled);
        }
    }
}