using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RoomBooking.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using RoomBooking.ViewModels;
using RoomBooking.Models;

namespace RoomBooking.Controllers
{
    [Route("admin/room")]
    [Authorize(Roles = "Admin")]
    public class RoomController : Controller
    {
        private ApplicationDbContext _context;

        public RoomController(
            ApplicationDbContext context
        )
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var rooms = await _context.Rooms.ToListAsync();
            return View("/Views/Admin/Room/Index.cshtml", rooms);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> detail(int id)
        {
            var room = await _context.Rooms.FindAsync(id);

            if (room != null)
            {
                return View("/Views/Admin/Room/Detail.cshtml", room);
            }
            return BadRequest("Không tồn tại phòng");
        }

        [HttpGet("book-room")]
        public async Task<IActionResult> BookRoom()
        {
            var room = await _context.BookRooms.Select(item => new BookRoomAdminViewModel
            {
                Id = item.Id,
                FullName = item.Customer.Name,
                Email = item.Customer.Email,
                Phone = item.Customer.Phone,
                TimeCreated = item.CreatedAt,
                TypeRoom = item.TypeRoom,
                TimeBook = item.TimeBook,
                CreatedAt = item.CreatedAt,
                Status = item.Status

            }).ToListAsync();

            return View("/Views/Admin/Room/BookRoom.cshtml", room);
        }

        [HttpGet("book-room/{id}")]
        public async Task<IActionResult> bookRoomDetail(int id)
        {

            var found = await _context.BookRooms.FindAsync(id);

            if (found != null)
            {
                var bookRoom = await _context.BookRooms
                                .Where(item => item.Id == id)
                                .Select(item => new BookRoom
                                {
                                    Id = item.Id,
                                    TypeRoom = item.TypeRoom,
                                    Customer = item.Customer,
                                    TimeCreated = item.TimeCreated,
                                    TimeBook = item.TimeBook,
                                    Status = item.Status,
                                    CreatedAt = item.CreatedAt
                                }).FirstAsync();

                ViewBag.Rooms = await _context.Rooms.ToListAsync();
                return View("/Views/Admin/Room/BookRoomDetail.cshtml", bookRoom);
            }
            return BadRequest("Không tồn tại bản ghi");
        }

        [HttpPost("book-room/{id}")]
        public async Task<IActionResult> updateBookRoom([FromForm] BookRoom model, int id)
        {
            var bookRoom = await _context.BookRooms.FindAsync(id);
            if (bookRoom != null)
            {
                if (ModelState.IsValid)
                {
                    bookRoom.RoomId = model.RoomId;
                    bookRoom.Status = true;
                    bookRoom.BookRoomStatus = BookRoomStatus.Booked;

                    await _context.SaveChangesAsync();
                    return Redirect("/admin/room/book-room");
                }

               
            }
            return BadRequest("Không tồn tại bản ghi");
        }
    }
}