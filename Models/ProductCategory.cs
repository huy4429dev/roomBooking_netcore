using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RoomBooking.Models
{
    public class ProductCategory
    {
        [Key]
        public int Id { get; set; }
        
        [Column(TypeName = "VARCHAR")]
        [StringLength(255)]
        public string Name { get; set; }
        public ICollection<BlogPostCategory> PostCategories { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}