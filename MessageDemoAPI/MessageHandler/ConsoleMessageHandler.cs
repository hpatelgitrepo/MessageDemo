using MessageHandler.Contracts;
using MessageModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageHandler
{
    public class ConsoleMessageHandler :  IMessageHandler
    {
        public async Task<MessageHandlerResponse> SaveMessage(string message)
        {
            //Write To Console 

            return await Task.Run(() => (new MessageHandlerResponse
            {
                Persisted = true,
                Message = $"Message '{message}' persisted to Console successfully"
            }));
        }
    }
}
