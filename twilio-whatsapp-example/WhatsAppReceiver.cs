using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Twilio.AspNet.Common;
using Twilio.AspNet.Core;
using Twilio.TwiML;
using twilio_whatsapp_example.Data;
using twilio_whatsapp_example.Models;

namespace twilio_whatsapp_example
{
    public class WhatsAppReceiver : TwilioController
    {


        public IMessageService MessageService { get; set; }


        public WhatsAppReceiver(IMessageService messageService)
        {
            MessageService = messageService;
        }

        /// <summary>
        /// Method for receicing replies via WebHook. Configure https://yourdomain.com/WhatsAppReceiver in your twilio console
        /// </summary>
        /// <param name="incomingMessage"></param>
        /// <returns></returns>
        public async Task<TwiMLResult> Index(SmsRequest incomingMessage)
        {

            
            var message = new Message
            {
                To = incomingMessage.To,
                From = incomingMessage.From,
                Body = incomingMessage.Body
            };

            //Store message to
            await MessageService.InsertAsync(message);


            //Just return a message in order to proof if the test was OK
            var messagingResponse = new MessagingResponse();
            messagingResponse.Message("Thank you, we received your message");


            return TwiML(messagingResponse);
        }


    }
}