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
            IEnumerable<Blood> bll = _bloodRepository.GetAll();
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

        public void updateEmergency(int quantity, BloodType bloodType)
        {
            List<Blood> bloods = (List<Blood>)_bloodRepository.GetAll();
            foreach (Blood blood in bloods) { 
                if(blood.BloodType == bloodType)
                {
                    blood.Quantity += quantity;
                    _bloodRepository.Update(blood);
                    break;
                }
            }
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
            //Id of each blood type in storage
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

            foreach (BloodOrderDto order in orders)
            {
                if (order.IsSent)
                {
                    //take sent blood
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
                    if (order.ABPlus > 0)
                    {
                        Blood blood = new Blood();
                        blood.BloodType = BloodType.ABPlus;
                        blood.Quantity = order.ABPlus;
                        addBlood(blood);
                    }
                    if (order.OPlus > 0)
                    {
                        Blood blood = new Blood();
                        blood.BloodType = BloodType.OPlus;
                        blood.Quantity = order.OPlus;
                        addBlood(blood);
                    }
                    if (order.AMinus> 0)
                    {
                        Blood blood = new Blood();
                        blood.BloodType = BloodType.AMinus;
                        blood.Quantity = order.AMinus;
                        addBlood(blood);
                    }
                    if (order.BMinus> 0)
                    {
                        Blood blood = new Blood();
                        blood.BloodType = BloodType.BMinus;
                        blood.Quantity = order.BMinus;
                        addBlood(blood);
                    }
                    if (order.ABMinus > 0)
                    {
                        Blood blood = new Blood();
                        blood.BloodType = BloodType.ABMinus;
                        blood.Quantity = order.ABMinus;
                        addBlood(blood);
                    }
                    if (order.OMinus > 0)
                    {
                        Blood blood = new Blood();
                        blood.BloodType = BloodType.OMinus;
                        blood.Quantity = order.OMinus;
                        addBlood(blood);
                    }
                }
                else
                {
                    //notify menager that order is not sent
                    Model.Notification notification = new Model.Notification();
                    notification.NotificationFor = Role.manager;
                    notification.Title = "Order not sent";
                    notification.Description = $"Blood bank: {order.BankEmail} has failed to send: " +
                        $"APlus: {order.APlus}, BPlus: {order.BPlus}, ABPlus: " +
                        $"{order.ABPlus}, OPlus: {order.OPlus}, AMinus: {order.AMinus}, BMinus: {order.BMinus}, " +
                        $"ABMinus: {order.ABMinus}, OMinus: {order.OMinus}";
                    _notificationRepository.Create(notification);
                }
            }
        }
        public bool StoreBlood(Blood blood)
        {
            List<Blood> bloodTypes = GetByRoom(4);
            foreach(Blood b in bloodTypes)
            {
                if (b.BloodType.Equals(blood.BloodType))
                {
                    b.Quantity += blood.Quantity;
                    _bloodRepository.Update(b);
                    return true;
                }
            }
            return false;
        }

        public List<Blood> GetByRoom(int roomNumber)
        {
            List<Blood> bloodTypes = new List<Blood>();
            foreach(Blood b in GetAll())
            {
                if(b.RoomId == roomNumber)
                    bloodTypes.Add(b);
            }
            return bloodTypes;
        }
    }
}
