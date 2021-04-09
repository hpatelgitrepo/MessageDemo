using MessageHandler.Contracts;
using MessageLogic.Contracts;
using MessageModel;
using MessageModel.Enums;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageLogic
{
    public class MessageLogic : IMessageLogic
    {
        private IHandlerFactory HandlerFactory { get; set; }
        private IAppSettingsLogic AppSettings { get; set; }
        public MessageLogic(IAppSettingsLogic appSettings, IHandlerFactory handlerFactory)
        {
            this.HandlerFactory = handlerFactory;
            this.AppSettings = appSettings;
        }
        public async Task<string> GetMessageAsync()
        {
            return await Task.FromResult("This message is returned from API");
        }

        public async Task<MessageHandlerResponse> SaveMessageAsync(string message)
        {
            if (!Enum.TryParse(await AppSettings.GetMessageHandlerTypeAppSettingsAsync(), out MessageHandlerType messageHandlerType))
                throw new ArgumentException("MessageHandlerType is invalid");

            var messageHandler = HandlerFactory.Resolve<IMessageHandler>(messageHandlerType);
            return await messageHandler.SaveMessage(message);
        }
    }
}
