using IntegrationLibrary.Core.Exceptions;
using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Service
{
    public class BloodBankService : IBloodBankService
    {

        private readonly IBloodBankRepository _bloodBankRepository;
        private readonly IAPIKeyService _apiKeyService;
        private readonly IPasswordService _passwordService;

        public BloodBankService(IBloodBankRepository bloodBankRepository, IAPIKeyService apiKeyService, IPasswordService passwordService)
        {
            _bloodBankRepository = bloodBankRepository;
            _apiKeyService = apiKeyService;
            _passwordService = passwordService;
        }

        public void Create(BloodBank entity)
        {
            SetupAPIKey(entity);
            entity.Password = _passwordService.GeneratePassword();
            _bloodBankRepository.Create(entity);
        }

        private void SetupAPIKey(BloodBank entity)
        {
            do
            {
                entity.ApiKey = _apiKeyService.GenerateKey();
            } while (_bloodBankRepository.CheckIfAPIKeyExists(entity.ApiKey));
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
        }
    }
}
