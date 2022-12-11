using HospitalLibrary.Core.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.IntegrationConnection
{
    public class IntegrationHTTPConnection : IIntegrationConnection
    {
        private static HttpClient client;
        private static LoginUserDto user;
        private static Boolean integrationResponse;
        public bool CheckIfExists(LoginUserDto _user)
        {
            client = new()
            {
                BaseAddress = new Uri("http://localhost:5000/")
            };
            user = _user;

            PostAsync(client).Wait();
            return integrationResponse;
        }

        static async Task<Boolean> PostAsync(HttpClient httpClient)
        {
            client.Timeout = TimeSpan.FromSeconds(120);
            StringContent stringContent = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
            using HttpResponseMessage response = await httpClient.PostAsync("api/BloodBank/CheckIfExists", stringContent);

            response.EnsureSuccessStatusCode();

            string isSuccessful = await response.Content.ReadAsStringAsync();
            integrationResponse = Boolean.Parse(isSuccessful);
            return integrationResponse;
        }
    }
}
