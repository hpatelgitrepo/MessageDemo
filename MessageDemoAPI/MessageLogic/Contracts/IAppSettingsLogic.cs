using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageLogic.Contracts
{
    public interface IAppSettingsLogic
    {
        Task<string> GetMessageHandlerTypeAppSettingsAsync();
    }
}
