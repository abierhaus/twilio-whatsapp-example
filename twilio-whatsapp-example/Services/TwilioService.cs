using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace twilio_whatsapp_example.Data
{
    public class TwilioService
    {
        public TwilioService(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        /// <summary>
        ///     Send WhatsApp via the Twilio API Service
        /// </summary>
        /// <param name="toNumber">Must be for +491701234567</param>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task Send(string toNumber, string message)
        {
            try
            {
                // Find your Account Sid and Token at twilio.com/console
                // and set the confif. See http://twil.io/secure
                var accountSid = Configuration["Twilio:TWILIO_ACCOUNT_SID"];
                var authToken = Configuration["Twilio:TWILIO_AUTH_TOKEN"];


                TwilioClient.Init(accountSid, authToken);

                var messageRessource = await MessageResource.CreateAsync(
                    body: message,
                    from: new PhoneNumber(Configuration["Twilio:TWILIO_FROM_CHANNEL"]),
                    to: new PhoneNumber($"whatsapp:{toNumber}")
                );
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}