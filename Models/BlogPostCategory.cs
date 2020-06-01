using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RoomBooking.Models
{
    public class  BlogPostCategory
    {
        public int CategoryId{get;set;}
        public virtual BlogCategory Category {get;set;}
        public int PostId{get;set;}
        public virtual BlogPost Post {get;set;}
        public DateTime CreatedAt{get;set;}
        public DateTime UpdatedAt{get;set;}
    }
}