using MessageHandler;
using MessageHandler.Contracts;
using MessageModel.Enums;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelloWorld
{
    public class HandlerFactory : IHandlerFactory
    {
        #region Public Constructors

        public HandlerFactory(Container container)
        {
            InternalContainer = container;
        }

        #endregion Public Constructors

        #region Private Properties

        private Container InternalContainer { get; set; }

        #endregion Private Properties

        #region Public Methods

        public T Resolve<T>(MessageHandlerType type)
            where T : class
        {
            T handler = null;
            var typeOfT = typeof(T);

            switch (type)
            {
                case MessageHandlerType.DatabaseMessageHandler:
                    handler = InternalContainer.GetInstance<DatabaseMessageHandler>() as T;
                    break;
                case MessageHandlerType.FileMessageHandler:
                    handler = InternalContainer.GetInstance<FileMessageHandler>() as T;
                    break;
                case MessageHandlerType.ConsoleMessageHandler:
                    handler = InternalContainer.GetInstance<ConsoleMessageHandler>() as T;
                    break;
            }

            return handler;
        }

        #endregion Public Methods
    }
}