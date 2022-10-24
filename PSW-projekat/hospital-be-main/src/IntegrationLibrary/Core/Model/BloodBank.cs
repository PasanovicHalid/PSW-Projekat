using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Model
{
    public class BloodBank : BaseModel
    {
        private string _name;

        private string _email;

        private string _password;

        private string _serverAddress;

        private string _apiKey;

        public BloodBank()
        {
        }

        public BloodBank(string name, string email, string password, string serverAddress, string apiKey)
        {
            Name = name;
            Email = email;
            Password = password;
            ServerAddress = serverAddress;
            ApiKey = apiKey;
        }
        public string Name { get => _name; set => _name = value; }

        [Required]
        public string Email { get => _email; set => _email = value; }
        [Required]
        public string Password { get => _password; set => _password = value; }

        [Required]
        public string ServerAddress { get => _serverAddress; set => _serverAddress = value; }
        [Required]
        public string ApiKey { get => _apiKey; set => _apiKey = value; }
    }
}
