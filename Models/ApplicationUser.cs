using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace RoomBooking.Models
{
    public class ApplicationUser : IdentityUser<int>
    {
        [Column(TypeName = "VARCHAR")]
        [StringLength(255)]
        public string FullName { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(255)]
        public string Password { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(255)]
        public string Avatar { get; set; }
        public ICollection<BlogPost> Posts { get; set; }
        public ICollection<Room> Rooms { get; set; }
        public ICollection<Order> Orders { get; set; }
    }

    public class ApplicationRole : IdentityRole<int>
    {


    }
}