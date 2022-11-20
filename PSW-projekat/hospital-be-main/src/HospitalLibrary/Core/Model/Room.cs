using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HospitalLibrary.Core.Model.Enums;

namespace HospitalLibrary.Core.Model
{
    public class Room : BaseModel
    {
        public string Number { get; set; }
        [Range(1, 10)]
        public int Floor { get; set; }
        public RoomType RoomType { get; set; }
        public virtual Equipment Equipment { get; set; }

    }
}
