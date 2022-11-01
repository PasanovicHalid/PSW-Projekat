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
        private static String bankAPI; 

        public bool SendBloodRequest(BloodBank bank, string bType, int quant)
        {
            client = new()
            {
                BaseAddress = new Uri(bank.ServerAddress)
            };  
            bloodType = bType;
            quantity = quant;
            bankEmail = bank.Email;
            bankAPI = bank.ApiKey;

            GetAsync(client).Wait();

            return bankResponse;
        }
        static async Task<bool> GetAsync(HttpClient httpClient)
        {
            client.Timeout = TimeSpan.FromSeconds(15);
            client.DefaultRequestHeaders.Add("Authorization","Bearer " + bankAPI);
            using HttpResponseMessage response = await httpClient.GetAsync("api/bloodbank/" + bankEmail + "/"  + bloodType + "/" + quantity);
            
            response.EnsureSuccessStatusCode();
            
            string hasBlood = await response.Content.ReadAsStringAsync();
            bankResponse = Boolean.Parse(hasBlood);
            return bankResponse;            
            
        }
    }
}
