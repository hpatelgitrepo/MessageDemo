using MessageHandler.Contracts;
using MessageModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageHandler
{
    public class DatabaseMessageHandler : IMessageHandler
    {
        public async Task<MessageHandlerResponse> SaveMessage(string message)
        {
            // Save to DB 

            return await Task.Run(() => new MessageHandlerResponse
            {
                Persisted = true,
                Message = $"Message '{message}' persisted to Database successfully"
            });
        }
    }
}
