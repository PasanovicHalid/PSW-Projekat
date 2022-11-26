using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HospitalLibrary.Core.Model.Enums;

namespace HospitalLibrary.Core.DTOs
{
    public class RoomDto
    {
        public int Id { get; set; }
        public string Number { get; set; }
        [Range(1, 10)]

        public int Floor { get; set; }
        public RoomType RoomType { get; set; }
        public virtual ICollection<BedDto> BedDtos { get; set; }

        public RoomDto() { }
        public RoomDto(int id, string number, int floor, RoomType roomType, ICollection<BedDto> bedDtos)
        {
            Id = id;
            Number = number;
            Floor = floor;
            RoomType = roomType;
            BedDtos = bedDtos;
        }
    }
}
