using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RoomBooking.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public int Amount { get; set; }

        [ForeignKey("Room")]
        public int RoomId { get; set; }
        public virtual Room Room { get; set; }

        [ForeignKey("ApplicationUser")]
        public int UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public ICollection<OrderDetail> OrderDetails{get;set;}
        public bool StatusOrder{get;set;}
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}