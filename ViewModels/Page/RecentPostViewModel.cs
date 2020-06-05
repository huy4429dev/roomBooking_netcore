using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using RoomBooking.Models;

namespace RoomBooking.ViewModels
{
    public class RecentPostViewModel
    {
        public string Title{get;set;}
        public string Thumbnail{get;set;}
        public string CategoryName{get;set;}
        public DateTime CreatedAt{get;set;}

    }
}