﻿using Microsoft.EntityFrameworkCore;
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

        private string _passwordResetKey;

        private AccountStatus _accountStatus;

        public BloodBank()
        {
        }

        public BloodBank(string name, string email, string serverAddress)
        {
            _name = name;
            _email = email;
            _serverAddress = serverAddress;
            _accountStatus = AccountStatus.PENDING;
        }

        public BloodBank(string name, string email, string password, string serverAddress, string apiKey, string passwordResetKey)
        {
            _name = name;
            _email = email;
            _password = password;
            _serverAddress = serverAddress;
            _apiKey = apiKey;
            _passwordResetKey = passwordResetKey;
            _accountStatus = AccountStatus.PENDING;
        }

        public BloodBank(string name, string email, string password, string serverAddress, string apiKey, string passwordResetKey, AccountStatus accountStatus)
        {
            Name = name;
            Email = email;
            Password = password;
            ServerAddress = serverAddress;
            ApiKey = apiKey;
            PasswordResetKey = passwordResetKey;
            AccountStatus = accountStatus;
        }

        public void ActivatePassword(string password)
        {
            Password = password;
            AccountStatus = AccountStatus.ACTIVE;
            PasswordResetKey = null;
        }
        public string Name { get => _name; set => _name = value; }

        [Required]
        public string Email { get => _email; set => _email = value; }
        
        public string Password { get => _password; set => _password = value; }

        [Required]
        public string ServerAddress { get => _serverAddress; set => _serverAddress = value; }
        [Required]
        public string ApiKey { get => _apiKey; set => _apiKey = value; }

        public string PasswordResetKey { get => _passwordResetKey; set => _passwordResetKey = value; }

        [Required]
        public AccountStatus AccountStatus { get => _accountStatus; set => _accountStatus = value; }
    }
}