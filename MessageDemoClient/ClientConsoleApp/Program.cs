using ClientConsoleApp;
using MessageModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp
{
    class Program
    {
        // TODO : This endpoint could come from DB or App.config
        private static string requestUri = "http://localhost:44333/api/message";
        static async Task Main(string[] args)
        {
            //Console.WriteLine(await GetMessage());
            Console.WriteLine("====== Message Operations =====");
            Console.WriteLine();
            Console.WriteLine("   1. Get Message");
            Console.WriteLine("   2. Save Message");
            Console.WriteLine();

            Console.Write("Please enter your choice : ");
            var choice = Console.ReadLine();
            if (choice == "1")
            {
                Console.WriteLine();
                Console.WriteLine(await GetMessage());
            }
            else if (choice == "2")
            {
                Console.Write("Please enter the message to save : ");
                var message = Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine(await SaveMessage(message));
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Wrong Choice!!");
            }
            Console.ReadLine();
        }

        private static async Task<string> GetMessage()
        {
            var client = new APIClient(requestUri);
            using (var response = await client.GetAsync(requestUri))
            {
                using (var contentStream = await response.Content.ReadAsStreamAsync())
                using (var contentReader = new StreamReader(contentStream))
                using (var jsonReader = new JsonTextReader(contentReader))
                {
                    return new JsonSerializer().Deserialize<string>(jsonReader);
                };
            }
        }

        private static async Task<string> SaveMessage(string message)
        {
            var client = new APIClient(requestUri);
            using (var response = await client.PostPreparedContentAsync(requestUri, message))
            {
                using (var contentStream = await response.Content.ReadAsStreamAsync())
                using (var contentReader = new StreamReader(contentStream))
                using (var jsonReader = new JsonTextReader(contentReader))
                {
                    return Newtonsoft.Json.JsonConvert.SerializeObject(new JsonSerializer().Deserialize<MessageHandlerResponse>(jsonReader));
                };
            }
        }
       
    }
}
