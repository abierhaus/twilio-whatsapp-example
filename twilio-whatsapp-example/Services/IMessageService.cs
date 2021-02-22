using System.Collections.Generic;
using System.Threading.Tasks;
using twilio_whatsapp_example.Models;

namespace twilio_whatsapp_example.Data
{
    public interface IMessageService
    {
        Task<List<Message>> GetMessagesAsync();
        Task InsertAsync(Message message);
    }
}