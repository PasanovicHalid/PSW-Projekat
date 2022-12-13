﻿using System;
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
        private static byte[] pdfFile;

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

        public async Task<bool> SendBloodReports(BloodBank bank, byte[] pdf)
        {
            client = new()
            {
                BaseAddress = new Uri(bank.ServerAddress)
            };
            pdfFile = pdf;
            bankEmail = bank.Email;
            bankAPI = bank.ApiKey;

            PostAsync(client).Wait();

            return bankResponse;
        }

        static async Task<bool> PostAsync(HttpClient httpClient)
        {
            string isSuccessful = "false";
            client.Timeout = TimeSpan.FromSeconds(120);
            ByteArrayContent byteContent = new ByteArrayContent(pdfFile);
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + bankAPI);
            using HttpResponseMessage response = await httpClient.PostAsync("api/bloodbank/" + bankEmail, byteContent);

            response.EnsureSuccessStatusCode();

            isSuccessful = await response.Content.ReadAsStringAsync();
            bankResponse = Boolean.Parse(isSuccessful);
            return bankResponse;

        }

        public async Task<bool> GetBlood(BloodBank bank, string bType, int quant)
        {
            client = new()
            {
                BaseAddress = new Uri(bank.ServerAddress)
            };

            GetAsync(client, bank, bType, quant).Wait();

            return bankResponse;
        }

        static async Task<bool> GetAsync(HttpClient httpClient, BloodBank bank, string bType, int quant)
        {
            client.Timeout = TimeSpan.FromSeconds(15);
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + bank.ApiKey);
            using HttpResponseMessage response = await httpClient.GetAsync("api/bloodbank/get/" + bank.Email + "/" + bType + "/" + quant);

            response.EnsureSuccessStatusCode();

            string hasBlood = await response.Content.ReadAsStringAsync();
            bankResponse = Boolean.Parse(hasBlood);
            return bankResponse;

        }
    }
}
