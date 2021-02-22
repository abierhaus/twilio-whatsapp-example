using System.Collections.Generic;
using System.Threading.Tasks;
using LiteDB;
using twilio_whatsapp_example.Models;

namespace twilio_whatsapp_example.Data
{
    public class MessageService : IMessageService
    {
        public const string DatabasePath = "TwilioWhatsAppExample.db";


        public async Task<List<Message>> GetMessagesAsync()

        {
            var messages = new List<Message>();

            using var db = new LiteDatabase(DatabasePath);
            var col = db.GetCollection<Message>("Messages");


            foreach (var item in col.Query().ToList())
            {
                var message = new Message {Body = item.Body, From = item.From, To = item.To};
                messages.Add(message);
            }

            return messages;
        }

        public async Task InsertAsync(Message message)
        {
            using var db = new LiteDatabase(DatabasePath);
            var col = db.GetCollection<Message>("Messages");
            col.Insert(message);
        }
    }
}