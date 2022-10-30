﻿using IntegrationLibrary.Core.Exceptions;
using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Model.MailRequests;
using IntegrationLibrary.Core.Repository.BloodBanks;
using IntegrationLibrary.Core.Service.Generators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Service.BloodBanks
{
    public class BloodBankService : IBloodBankService
    {

        private readonly IBloodBankRepository _bloodBankRepository;
        private readonly IEmailService _emailService;
        private readonly APIKeyGenerator _apiKeyGenerator = new APIKeyGenerator();
        private readonly PasswordGenerator _passwordGenerator = new PasswordGenerator();

        public BloodBankService(IBloodBankRepository bloodBankRepository, IEmailService emailService)
        {
            _bloodBankRepository = bloodBankRepository;
            _emailService = emailService;
        }

        public void Create(BloodBank entity)
        {
            try
            {
                CheckIfBankCanBeCreated(entity);
                SetupBloodBank(entity);
                _bloodBankRepository.Create(entity);
                _emailService.SendEmailAsync(new BloodBankCreationMailRequest(entity));
            } catch
            {
                throw;
            }
        }

        private void SetupBloodBank(BloodBank entity)
        {
            do
            {
                entity.ApiKey = _apiKeyGenerator.GenerateKey();
            } while (_bloodBankRepository.CheckIfAPIKeyExists(entity.ApiKey));

            entity.Password = _passwordGenerator.GeneratePassword();

            do
            {
                entity.PasswordResetKey = _passwordGenerator.GeneratePasswordResetKey();
            } while (_bloodBankRepository.CheckIfPasswordResetKeyExists(entity.PasswordResetKey));
        }


        private void CheckIfBankCanBeCreated(BloodBank entity)
        {
            if (_bloodBankRepository.CheckIfEmailExists(entity.Email))
            {
                throw new EmailAlreadyExistsException();
            }
        }

        public void Delete(BloodBank entity)
        {
            _bloodBankRepository.Delete(entity);
        }

        public IEnumerable<BloodBank> GetAll()
        {
            return _bloodBankRepository.GetAll();
        }

        public BloodBank GetById(int id)
        {
            return _bloodBankRepository.GetById(id);
        }

        public void Update(BloodBank entity)
        {
            CheckIfBankIsUpdatable(entity);
            _bloodBankRepository.Update(entity);
        }

        private void CheckIfBankIsUpdatable(BloodBank entity)
        {
            if (_bloodBankRepository.CheckIfAPIKeyIsUpdatable(entity))
            {
                throw new APIKeyExistsException();
            }
            if (_bloodBankRepository.CheckIfEmailIsUpdatable(entity))
            {
                throw new EmailAlreadyExistsException();
            }
            if (_bloodBankRepository.CheckIfPasswordResetKeyIsUpdatable(entity))
            {
                throw new PasswordKeyExistsException();
            }
        }

        public bool CheckIfPasswordResetKeyExists(string passwordResetKey)
        {
            return _bloodBankRepository.CheckIfPasswordResetKeyExists(passwordResetKey);
        }

        public BloodBank GetBloodBankFromPasswordResetKey(string passwordResetKey)
        {
            return _bloodBankRepository.GetBloodBankFromPasswordResetKey(passwordResetKey);
        }
    }
}
