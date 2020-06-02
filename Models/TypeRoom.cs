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
        [Required(ErrorMessage = "Vui lòng nhập tên loại phòng")]
        public string Name { get; set; }
        
        [Column(TypeName = "VARCHAR")]
        [StringLength(500)]
        [Required(ErrorMessage = "Vui lòng nhập mô tả")]
        public string Description { get; set; }
        
        [Column(TypeName = "VARCHAR")]
        [StringLength(255)]
        [Required(ErrorMessage = "Vui lòng chọn hình ảnh")]
        public string Thumbnail { get; set; }
        [Required(ErrorMessage = "Vui lòng chọn mức giá")]
        public int? Price { get; set; }
        public float Rate { get; set; }
        public ICollection<Room> Rooms { get; set; }
        public ICollection<TypeRoomService> TypeRoomServices { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}