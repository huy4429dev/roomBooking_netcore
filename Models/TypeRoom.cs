using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RoomBooking.Models
{
    public class TypeRoom
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(255)]
        public string Name { get; set; }
        
        [Column(TypeName = "VARCHAR")]
        [StringLength(500)]
        public string Description { get; set; }
        
        [Column(TypeName = "VARCHAR")]
        [StringLength(255)]
        public string Thumbnail { get; set; }
        public int Price { get; set; }
        public float Rate { get; set; }
        public ICollection<Room> Rooms { get; set; }
        public ICollection<TypeRoomService> TypeRoomServices { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}