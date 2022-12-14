using HospitalLibrary.Core.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Model
{
    public class Notification : BaseModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Role NotificationFor { get; set; }
    }
}
