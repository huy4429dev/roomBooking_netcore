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
        public string Name { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(255)]
        public string Email { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(15)]
        public string Phone { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(500)]
        public string Subject { get; set; }
        public string Content { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}