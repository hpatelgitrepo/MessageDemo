using MessageLogic.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace HelloWorld.Controllers
{
    [RoutePrefix("api/message")]
    public class MessageController : ApiController
    {
        private readonly IMessageLogic messageLogic;

        public MessageController(IMessageLogic messageLogic)
        {
            this.messageLogic = messageLogic;
        }
       
        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            return Ok(await messageLogic.GetMessageAsync());
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody] string value)
        {
            return Ok(await messageLogic.SaveMessageAsync(value));
        }
    }
}