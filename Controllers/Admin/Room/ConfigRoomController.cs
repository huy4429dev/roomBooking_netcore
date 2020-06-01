using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RoomBooking.Models;
using System;
using System.Threading.Tasks;
using RoomBooking.Data;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace RoomBooking.Controllers
{
    [Route("admin/room")]
    public class ConfigRoomController : Controller
    {
        private ApplicationDbContext _context;

        public ConfigRoomController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("config")]
        public IActionResult Index()
        {
            return View("Views/Admin/Room/ConfigRoom.cshtml");
        }

        [HttpPost("config")]
        public async Task<IActionResult> Config()
        {
            var countRoom = Request.Form["countRoom"][0];
            var roomId = Request.Form["roomId"][0];
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            _context.Database.ExecuteSqlRaw("DELETE FROM public.\"Rooms\"");

            for (int i = 0; i < Convert.ToInt32(countRoom); i++)
            {

                await _context.Rooms.AddAsync(new Room
                {
                    RoomId = roomId + " - " + i,
                    Thumbnail = "/uploads/house.png",
                    TypeRoomId = 1,
                    UserId = Convert.ToInt32(userId)

                });

                await _context.SaveChangesAsync();
            }

            return RedirectToAction("index", "room");
        }

        [HttpGet("make-type")]
        public async Task<IActionResult> MakeTypeRoom()
        {
            await _context.TypeRooms.AddAsync(new TypeRoom
            {
                Name = "default",
                Description = "default",
                Thumbnail = "default",
                Price = 1,
                Rate = 5
            });

            await _context.SaveChangesAsync();
            return Ok(1);
        }
    }

}