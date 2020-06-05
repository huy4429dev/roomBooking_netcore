using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RoomBooking.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(255)]
        [Required(ErrorMessage = "Vui lòng nhập họ tên")]
        public string Name { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(255)]
        [Required(ErrorMessage = "Vui lòng nhập email")]

        public string Email { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(15)]
        [Required(ErrorMessage = "Vui lòng nhập số điện thoại")]

        public string Phone { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(500)]
        [Required(ErrorMessage = "Vui lòng nhập chủ đề")]

        public string Subject { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập nội dung")]

        public string Content { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}