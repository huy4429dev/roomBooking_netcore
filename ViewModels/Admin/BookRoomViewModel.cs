using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using RoomBooking.Models;

namespace RoomBooking.ViewModels
{
    public class BookRoomAdminViewModel
    {

        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime TimeCreated { get; set; }
        public int TimeBook { get; set; }
        public Boolean Status { get; set; }
        public TypeRoom TypeRoom { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}