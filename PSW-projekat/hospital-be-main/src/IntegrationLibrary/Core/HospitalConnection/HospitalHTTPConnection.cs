using HospitalLibrary.Core.DTOs;
using IntegrationLibrary.Core.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.HospitalConnection
{
    public class HospitalHTTPConnection : IHospitalConnection
    {
        private static HttpClient client;
        private static LoginUserDto user;
        public void GenereteJWT(LoginUserDto _user)
        {
            client = new()
            {
                BaseAddress = new Uri("http://localhost:16177/")
            };
            user = _user;

            PostAsync(client).Wait();
        }

        static async Task<String> PostAsync(HttpClient httpClient)
        {
            string isSuccessful = "false";
            client.Timeout = TimeSpan.FromSeconds(120);
            StringContent stringContent = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
            using HttpResponseMessage response = await httpClient.PostAsync("api/Account/LoginBank", stringContent);

            response.EnsureSuccessStatusCode();

            isSuccessful = await response.Content.ReadAsStringAsync();
            return isSuccessful;
        }
    }
}
