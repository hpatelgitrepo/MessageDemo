using MessageModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageHandler.Contracts
{
    public interface IMessageHandler
    {
        Task<MessageHandlerResponse> SaveMessage(string message);
    }
}
