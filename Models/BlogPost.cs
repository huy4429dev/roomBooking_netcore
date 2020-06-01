using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RoomBooking.Models
{
    public class BlogPost
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(255)]
        [Required(ErrorMessage = "Vui lòng nhập tiêu đề")]
        public string Title { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(255)]

        [Required(ErrorMessage = "Vui lòng thêm ảnh đại diện")]
        public string Thumbnail { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(500)]
        [Required(ErrorMessage = "Vui lòng nhập mô tả")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập nội dung")]
        public string Content { get; set; }
        public int UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public ICollection<BlogPostCategory> PostCategories { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}