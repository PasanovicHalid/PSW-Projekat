using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Model
{
    public class BloodBank
    {
        private int _id;

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

        [Key]
        public int Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }

        [Required]
        [EmailAddress]
        public string Email { get => _email; set => _email = value; }
        public string Password { get => _password; set => _password = value; }

        [Url]
        public string ServerAddress { get => _serverAddress; set => _serverAddress = value; }
        public string ApiKey { get => _apiKey; set => _apiKey = value; }
    }
}
