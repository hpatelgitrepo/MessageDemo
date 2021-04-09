using MessageModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageLogic.Contracts
{
    public interface IMessageLogic
    {
        Task<string> GetMessageAsync();

        Task<MessageHandlerResponse> SaveMessageAsync(string message);
    }
}
