using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using twilio_whatsapp_example.Data;
using twilio_whatsapp_example.Models;

namespace twilio_whatsapp_example.Pages
{
    public partial class Receive
    {
        
        [Inject]
        public IMessageService MessageService { get; set; }


        public List<Message> Messages { get; set; }

        protected override async Task OnInitializedAsync()
        {
            //Get Messages

            Messages = await MessageService.GetMessagesAsync();
        }
    }
}
