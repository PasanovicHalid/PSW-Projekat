using IntegrationLibrary.Core.Model.MailRequests;
using IntegrationLibrary.Core.Model.Tender;
using IntegrationLibrary.Core.Repository.Bids;
using IntegrationLibrary.Core.Repository.BloodBanks;
using IntegrationLibrary.Core.Repository.Tenders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Service.Bids
{
    public class BidService : IBidService
    {
        private readonly ITenderRepository _tenderRepository;
        private readonly IBidRepository _bidRepository;
        private readonly IEmailService _emailService;
        private readonly IBloodBankRepository _bloodBankRepository;

        public BidService(IBidRepository bidRepository, ITenderRepository tenderRepository, IEmailService emailService, IBloodBankRepository bloodBankRepository) 
        {
                _bidRepository = bidRepository;
            _tenderRepository = tenderRepository;
            _emailService = emailService;
            _bloodBankRepository = bloodBankRepository;

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
                Tender tender = _tenderRepository.GetById(Winner.TenderOfBidId);
                List<Bid> all = (List<Bid>)GetByTenderId(_bidRepository.GetById(id).TenderOfBidId);
                UpdateBids(Winner, all);
                SendEmailsToParticipants(Winner, tender, all);
                tender.State = TenderState.CLOSED;
                _tenderRepository.Update(tender);
            }
            catch
            {
                throw;
            }
        }

        private async void SendEmailsToParticipants(Bid Winner, Tender tender, List<Bid> all)
        {
            await _emailService.SendEmailAsync(new TenderWinnermailRequest(_bloodBankRepository.GetById(Winner.BloodBankId), tender));
            HashSet<int> bloodBanksWhoRecievedEmail = new HashSet<int>
            {
                Winner.BloodBankId
            };
            foreach (Bid loser in all)
            {
                if (!bloodBanksWhoRecievedEmail.Contains(loser.BloodBankId))
                {
                    await _emailService.SendEmailAsync(new TenderLoserMailRequest(_bloodBankRepository.GetById(loser.BloodBankId), tender));
                    bloodBanksWhoRecievedEmail.Add(loser.BloodBankId);
                }    
            }
        }

        private void UpdateBids(Bid winner,List<Bid> all)
        {
            foreach (Bid loser in all)
            {
                loser.Status = BidStatus.LOST;
                _bidRepository.Update(loser);
            }
            winner.Status = BidStatus.WIN;
            _bidRepository.Update(winner);
        }


        public void Update(Bid entity)
        {
            _bidRepository.Update(entity);
        }

       
    }
}
