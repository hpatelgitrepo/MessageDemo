using MessageModel.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageHandler.Contracts
{
    public interface IHandlerFactory
    {
        T Resolve<T>(MessageHandlerType MessageHandlerType)
            where T : class;
    }
}
