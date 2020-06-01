using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RoomBooking.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(255)]

        public string Name { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(255)]
        public string Email { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(15)]
        public string Phone { get; set; }
        
        [Column(TypeName = "VARCHAR")]
        [StringLength(255)]
        public string Avatar { get; set; }
        public ICollection<Order> Orders { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}