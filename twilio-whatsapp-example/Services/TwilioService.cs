using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace twilio_whatsapp_example.Data
{
    public class TwilioService 
    {
        private readonly IConfigurationRoot ConfigRoot;

        public TwilioService(IConfiguration configRoot)
        {
            ConfigRoot = (IConfigurationRoot)configRoot;
        }

        /// <summary>
        /// Send WhatsApp via the Twilio API Service
        ///  </summary>
        /// <param name="toNumber">Must be for +491701234567</param>
        /// <param name="message"></param>
        /// <returns></returns>
  
        public async Task Send(string toNumber, string message)
        {
            try
            {
                // Find your Account Sid and Token at twilio.com/console
                // and set the confif. See http://twil.io/secure
                string accountSid = ConfigRoot.GetSection("Twilio")["TWILIO_ACCOUNT_SID"];
                string authToken = ConfigRoot.GetSection("Twilio")["TWILIO_AUTH_TOKEN"];


                TwilioClient.Init(accountSid, authToken);

                var messageRessource = await MessageResource.CreateAsync(
                    body: message,
                    @from: new Twilio.Types.PhoneNumber(ConfigRoot.GetSection("Twilio")["TWILIO_FROM_CHANNEL"]),
                    to: new Twilio.Types.PhoneNumber($"whatsapp:{toNumber}")
                );


                var a = messageRessource.ToString();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        
        }
    }
}