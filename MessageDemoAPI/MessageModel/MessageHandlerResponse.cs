using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageModel
{
    public class MessageHandlerResponse
    {
        public bool Persisted { get; set; }

        public string Message { get; set; }
    }
}
