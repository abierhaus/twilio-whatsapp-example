using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LiteDB;
using twilio_whatsapp_example.Models;

namespace twilio_whatsapp_example.Data
{

    /// <summary>
    /// Service for storing messages. For demonstration purpose we use LiteDB here.
    /// By implementing IMessageService you can use your own service/ repository
    /// </summary>
    public class MessageService : IMessageService
    {
        /// <summary>
        /// Path to the local database
        /// </summary>
        public const string DatabasePath = @"Filename=TwilioWhatsAppExample.db; Connection=shared";

        /// <summary>
        /// Table name for the messages
        /// </summary>
        public const string MessageTable = "Messages";

        public async Task<List<Message>> GetMessagesAsync()

        {
            var messages = new List<Message>();

            try
            {
                using var db = new LiteDatabase(DatabasePath);
                var col = db.GetCollection<Message>(MessageTable);


                foreach (var item in col.Query().ToList())
                {
                    var message = new Message { Body = item.Body, From = item.From, To = item.To };
                    messages.Add(message);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
             
            }

        

            return messages;
        }

        public async Task InsertAsync(Message message)
        {
            try
            {
                using var db = new LiteDatabase(DatabasePath);
                var col = db.GetCollection<Message>(MessageTable);
                col.Insert(message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
             
            }
           
        }
    }
}