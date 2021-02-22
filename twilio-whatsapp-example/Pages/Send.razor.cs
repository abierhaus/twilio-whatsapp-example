using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using twilio_whatsapp_example.Data;

namespace twilio_whatsapp_example.Pages
{
 


    public partial class Send
    {
        [Inject]
        public TwilioService TwilioService { get; set; }

        public string Content { get; set; }
        public string To { get; set; }


        public string Message { get; set; }


        private async Task SendWhatsAppAsync()
        {


            await TwilioService.Send(To, Content);


            Message = "WhatsApp send. Check your mobile";
            
        }

    }


}
