using IntegrationLibrary.Core.Model.Tender;
using IntegrationLibrary.Core.Repository.Bids;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Service.Bids
{
    public class BidService : IBidService
    {
        private readonly IBidRepository _bidRepository;

        public BidService(IBidRepository bidRepository) 
        {
                _bidRepository = bidRepository;
        }
        public void Create(Bid entity)
        {
            try
            {
                _bidRepository.Create(entity);
            }
            catch
            {
                throw;
            }
        }

        public void Delete(Bid entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Bid> GetAll()
        {
            try
            {
                return _bidRepository.GetAll();
            }
            catch
            {
                throw;
            }
        }

        public Bid GetById(int id)
        {
            return _bidRepository.GetById(id);
        }

        public IEnumerable<Bid> GetByTenderId(int id)
        {
            try
            {
                return _bidRepository.GetByTenderId(id);
            }
            catch
            {
                throw;
            }
        }

        public void SelectWinner(int id)
        {
            try
            {
            Bid Winner = _bidRepository.GetById(id);
            List<Bid> Losers = FindLosers(id);
                UpdateBids(Winner, Losers);
            }
            catch
            {
                throw;
            }
        }

        private void UpdateBids(Bid winner,List<Bid> losers)
        {
            winner.Status = BidStatus.WIN;
            _bidRepository.Update(winner);
            foreach (Bid loser in losers)
            {
                loser.Status = BidStatus.LOST;
                _bidRepository.Update(loser);
            }
        }

        private List<Bid> FindLosers(int id) {
            List<Bid> Losers = (List<Bid>)GetByTenderId(_bidRepository.GetById(id).TenderOfBidId);
            foreach (Bid loser in Losers)
            {
                if(loser.Id == id)
                {
                    Losers.Remove(loser);
                    break;
                }
            }
            return Losers;
        }

        public void Update(Bid entity)
        {
            _bidRepository.Update(entity);
        }

       
    }
}
