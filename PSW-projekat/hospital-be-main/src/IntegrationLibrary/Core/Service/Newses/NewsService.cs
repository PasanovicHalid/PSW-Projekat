﻿using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Repository.Newses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Service.Newses
{
    public class NewsService : INewsService
    {
        private readonly INewsRepository _newsRepository;
        private readonly IRabbitMQService _rabbitMQService;
        public NewsService(INewsRepository newsRepository, IRabbitMQService rabbitMQService)
        {
            _newsRepository = newsRepository;
            _rabbitMQService = rabbitMQService;
        }
        public void Create(News entity)
        {
            try
            {
                _newsRepository.Create(entity);
            } catch
            {
                throw;
            }
        }

        public void Delete(News entity)
        {
            try
            {
                _newsRepository.Delete(entity);
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<News> GetAll()
        {
            try
            {
                return _newsRepository.GetAll();
            } catch
            {
                throw;
            }
        }

        public News GetById(int id)
        {
            try
            {
                return _newsRepository.GetById(id);
            } catch
            {
                throw;
            }
        }

        public IEnumerable<News> GetOldNewsForBloodBank(int bloodBankId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<News> GetUpcomingNewsForBloodBank(int bloodbankId)
        {
            throw new NotImplementedException();
        }

        public void Update(News entity)
        {
            try
            {
                _newsRepository.Update(entity);
            } catch
            {
                throw;
            }
        }
        public IEnumerable<News> GetAllPending()
        {
            //_rabbitMQService.Send();
            List<News> recivedNews =_rabbitMQService.Recive();
            foreach (News entity in recivedNews)
            {
                Create(entity);
            }
            return _newsRepository.GetAllPending();
       }
    }
}
