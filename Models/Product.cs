using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RoomBooking.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        public string ProductId { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(255)]
        public string Name { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(255)]
        public string Thumbnail { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(500)]
        public string Description { get; set; }
        public int Price { get; set; }

        [ForeignKey("ApplicationUser")]
        public int UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        [ForeignKey("ProductCategory")]
        public int CategoryId { get; set; }
        public virtual ProductCategory Category { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}