using HospitalLibrary.Core.DTOs;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository;
using System.Collections.Generic;

namespace HospitalLibrary.Core.Service
{
    public class FeedbackService : IService<Feedback>
    {
        private readonly FeedbackRepository _feedbackRepository;

        public FeedbackService(FeedbackRepository feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;
        }

        public void Create(Feedback entity)
        {
            _feedbackRepository.Create(entity);
        }

        public void Delete(Feedback entity)
        {
            _feedbackRepository.Delete(entity);
        }

        public IEnumerable<Feedback> GetAll()
        {
            return _feedbackRepository.GetAll();
        }

        public Feedback GetById(int id)
        {
            return _feedbackRepository.GetById(id);
        }

        public void Update(Feedback entity)
        {
            _feedbackRepository.Update(entity);
        }

        public List<FeedbackDto> GetAllFeedbackDtos()
        {
            IEnumerable<Feedback> allFeedbacks = _feedbackRepository.GetAll();
            List<FeedbackDto> feedbackDtos = new();

            foreach (Feedback feedback in allFeedbacks)
            {
                FeedbackDto feedbackDto = new();
                feedbackDto.FeedbackId = feedback.Id;
                feedbackDto.Description = feedback.Description;

                if (feedback.IsAnonimous)
                    feedbackDto.Username = "Anonymous";
                else
                    feedbackDto.Username = feedback.User.Name + " " + feedback.User.Surname;

                feedbackDto.Public = feedback.IsPublic ? "Public" : "Private";
                feedbackDto.DateCreated = feedback.DateCreated.ToString().Split(' ')[0];
                feedbackDto.Status = feedback.Status.ToString();
                feedbackDtos.Add(feedbackDto);
            }
            return feedbackDtos;
        }

        public List<FeedbackDto> GetAllFeedbackPublicDtos()
        {
            IEnumerable<Feedback> allFeedbacks = _feedbackRepository.GetAll();
            List<FeedbackDto> feedbackDtos = new();

            foreach (Feedback feedback in allFeedbacks)
            {
                if (feedback.IsPublic && feedback.Status == Model.Enums.FeedbackStatus.Approved)
                {
                    FeedbackDto feedbackDto = new();
                    feedbackDto.FeedbackId = feedback.Id;
                    feedbackDto.Description = feedback.Description;

                    if (feedback.IsAnonimous)
                        feedbackDto.Username = "Anonymous";
                    else
                        feedbackDto.Username = feedback.User.Name + " " + feedback.User.Surname;

                    feedbackDto.Public = "Public";
                    feedbackDto.DateCreated = feedback.DateCreated.ToString().Split(' ')[0];
                    feedbackDto.Status = "Approved";
                    feedbackDtos.Add(feedbackDto);
                }
            }
            return feedbackDtos;
        }
        
    }
}
