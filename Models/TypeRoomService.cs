using System;
using System.ComponentModel.DataAnnotations;

namespace RoomBooking.Models
{
    public class TypeRoomService
    {

        public int TypeRoomId { get; set; }
        public virtual TypeRoom TypeRoom { get; set; }
        public int ServiceId { get; set; }
        public virtual Service Service { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}