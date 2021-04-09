using MessageLogic.Contracts;
using MessageModel.Enums;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageLogic
{
    public class AppSettingsLogic : IAppSettingsLogic
    {
        public async Task<string> GetMessageHandlerTypeAppSettingsAsync()
        {
            var messageHandlerTypeAppsettings = ConfigurationManager.AppSettings["MessageHandlerType"];
            return await Task.FromResult(messageHandlerTypeAppsettings);
        }
    }
}
