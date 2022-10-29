using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using IntegrationLibrary.Core.Model;

namespace IntegrationLibrary.Core.BloodBankConnection
{
    public class BloodBankHTTPConnection : IBloodBankConnection
    {
        private static HttpClient client;
        private static string bloodType;
        private static int quantity;
        private static String bankEmail;
        private static Boolean bankResponse;

        public bool sendBloodRequest(BloodBank bank, string bType, int quant)
        {
            client = new()
            {
                BaseAddress = new Uri(bank.ServerAddress)
            };
            bloodType = bType;
            quantity = quant;
            bankEmail = bank.Email;

            GetAsync(client).Wait();

            return bankResponse;
        }
        static async Task GetAsync(HttpClient httpClient)
        {
         
            using HttpResponseMessage response = await httpClient.GetAsync("api/bloodbank/" + bloodType + "/" + quantity);
            try
            {
                response.EnsureSuccessStatusCode();
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
            var jsonResponse = await response.Content.ReadAsStringAsync();

            Console.WriteLine(jsonResponse);
            bankResponse = Boolean.Parse(jsonResponse);

            // WriteLine($"{jsonResponse}\n");

            // Expected output:
            //   GET https://jsonplaceholder.typicode.com/todos/3 HTTP/ 1.1
            //   {
            //     "userId": 1,
            //     "id": 3,
            //     "title": "fugiat veniam minus",
            //     "completed": false
            //   }
        }
    }
}
