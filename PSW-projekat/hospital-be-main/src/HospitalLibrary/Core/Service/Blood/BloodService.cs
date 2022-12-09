using System;
using System.Collections.Generic;
using HospitalLibrary.Core.DTOs;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Model.Enums;
using HospitalLibrary.Core.Repository;
using HospitalLibrary.Core.Repository.Notification;

namespace HospitalLibrary.Core.Service
{
    public class BloodService : IBloodService
    {
        private readonly IBloodRepository _bloodRepository;
        private readonly INotificationRepository _notificationRepository;

        public BloodService(IBloodRepository bloodRepository, INotificationRepository notificationRepository)
        {
            _bloodRepository = bloodRepository;
            _notificationRepository = notificationRepository;

        }
        public void Create(Blood entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Blood entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Blood> GetAll()
        {
            return _bloodRepository.GetAll();
        }

        public Blood GetById(int id)
        {
            return _bloodRepository.GetById(id);
        }

        public void Update(Blood blood)
        {
            blood.Deleted = false;
            _bloodRepository.Update(blood);
        }
        public void updateQuantityBlood(int bloodId, int quantity, Blood blood)
        {
            Blood blood1 = _bloodRepository.GetById(bloodId);

            int kolicina = blood1.Quantity;
            blood1.Quantity = kolicina - quantity;

            _bloodRepository.Update(blood1);
        }
        private void addBlood(Blood inBlood)
        {
            //APlus => id = 5
            //BPlus => id = 6
            //ABPlus => id = 7
            //OPlus => id = 8
            //AMinus => id = 9
            //BMinus => id = 10
            //ABMinus => id = 11
            //OMinus  => id = 12
            Blood outBlood = new Blood();
            switch (inBlood.BloodType)
            {
                case BloodType.APlus:
                    outBlood = _bloodRepository.GetById(5);
                    break;
                case BloodType.BPlus:
                    outBlood = _bloodRepository.GetById(6);
                    break;
                case BloodType.ABPlus:
                    outBlood = _bloodRepository.GetById(7);
                    break;
                case BloodType.OPlus:
                    outBlood = _bloodRepository.GetById(8);
                    break;
                case BloodType.AMinus:
                    outBlood = _bloodRepository.GetById(9);
                    break;
                case BloodType.BMinus:
                    outBlood = _bloodRepository.GetById(10);
                    break;
                case BloodType.ABMinus:
                    outBlood = _bloodRepository.GetById(11);
                    break;
                case BloodType.OMinus:
                    outBlood = _bloodRepository.GetById(12);
                    break;
                default:
                    //
                    break;
            }
            outBlood.Quantity += inBlood.Quantity;
            _bloodRepository.Update(outBlood);
        }
        public void handleBloodRequest(List<BloodOrderDto> orders)
        {
            
            foreach(BloodOrderDto order in orders)
            {
                if (order.IsSent)
                {
                    //update blood
                    if (order.APlus > 0)
                    {
                        Blood blood = new Blood();
                        blood.BloodType = BloodType.APlus;
                        blood.Quantity = order.APlus;
                        addBlood(blood);
                    }
                    if (order.BPlus > 0)
                    {
                        Blood blood = new Blood();
                        blood.BloodType = BloodType.BPlus;
                        blood.Quantity = order.BPlus;
                        addBlood(blood);
                    }
                }
                else
                {
                    //notify menager
                    Model.Notification notification = new Model.Notification();
                    notification.NotificationFor = Role.manager;
                    notification.Title = "Order not sent";
                    notification.Description = "Blood bank: " + order.BankEmail + "has failed to send: " + 
                        "APlus: " + order.APlus + ", BPlus: " + order.BPlus;
                    _notificationRepository.Create(notification);
                }
            }
            

        }
    }
}
