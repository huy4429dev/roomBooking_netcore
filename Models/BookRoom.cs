using System;
using System.ComponentModel.DataAnnotations;

namespace RoomBooking.Models
{
    public class BookRoom
    {
        [Key]
        public int Id { get; set; }
        public int TypeRoomId { get; set; }
        public virtual TypeRoom TypeRoom { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public DateTime TimeCreated { get; set; }
        public int TimeBook { get; set; }
        public Boolean Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int? RoomId{get;set;}
        public virtual Room Room{get;set;}
        public BookRoomStatus BookRoomStatus{get;set;}
        
    }
}