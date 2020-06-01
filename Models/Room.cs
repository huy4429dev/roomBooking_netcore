using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RoomBooking.Models
{
    public class Room
    {
        [Key]
    public int Id { get; set; }

        public string RoomId { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(255)]
        public string Thumbnail { get; set; }

        [ForeignKey("TypeRoom")]
        public int? TypeRoomId { get; set; }
        public virtual TypeRoom TypeRoom { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(15)]
        public string Phone { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(255)]
        public string Name { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(255)]
        public string Address { get; set; }

        [ForeignKey("ApplicationUser")]
        public int? UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public StatusRoom StatusRoom { get; set; }

        public ICollection<Order> Orders { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}