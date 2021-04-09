using MessageHandler.Contracts;
using MessageModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageHandler
{
    public class FileMessageHandler : IMessageHandler
    {
        public async Task<MessageHandlerResponse> SaveMessage(string message)
        {
            // Write to File 

            return await Task.Run(() => new MessageHandlerResponse
            {
                Persisted = true,
                Message = $"Message '{message}' persisted to File successfully"
            });
        }
    }
}
