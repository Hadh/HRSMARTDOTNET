using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HRSmart.Utility;
using Microsoft.AspNet.SignalR;

namespace HRSmart.Hubs
{
    public class SupportHub : Hub
    {
        static ApiAiUtility ai = new ApiAiUtility();
        public void Send(string message)
        {
            var response = ai.Ai.TextRequest(message);
            
            if (response.Result.GetStringParameter("subject") != "" &&
                response.Result.GetStringParameter("description") != "")
            {
                
            }
            Clients.All.echoBack(response.Result.Fulfillment.Speech);
            
        }
    }
}