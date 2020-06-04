using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using RoomBooking.Models;

namespace RoomBooking.ViewModels
{
    public class BookRoomViewModel
    {

        [Required(ErrorMessage = "Vui lòng nhập tên người dùng")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập số điện thoại")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn ngày đặt phòng")]
        public DateTime? TimeCreated { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn thời gian đặt")]
        public int? TimeBook { get; set; }
        public int TypeRoomId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}