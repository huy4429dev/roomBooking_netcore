using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RoomBooking.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using RoomBooking.ViewModels;
using RoomBooking.Models;
using System;

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
            var rooms = await _context.Rooms
                        .Select(item => new Room
                        {
                            Id = item.Id,
                            RoomId = item.RoomId,
                            Thumbnail = item.Thumbnail,
                            StatusRoom = item.StatusRoom,
                            BookRooms = item.BookRooms.Where(item => item.TimeCreated >= DateTime.Now)
                                                        .Select(item => new BookRoom
                                                        {
                                                            TimeBook = item.TimeBook,
                                                            TimeCreated = item.TimeCreated,
                                                            Customer = item.Customer
                                                        }).ToList()
                        })
                        .ToListAsync();
            return View("/Views/Admin/Room/Index.cshtml", rooms);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> detail(int id)
        {
            var room = await _context.Rooms.FindAsync(id);

            if (room != null)
            {
                ViewBag.TypeRoom = await _context.TypeRooms.ToListAsync();
                return View("/Views/Admin/Room/Detail.cshtml", room);
            }
            return BadRequest("Không tồn tại phòng");
        }

        [HttpPost("update/{id}")]
        public async Task<IActionResult> update([FromForm] Room model, int id)
        {

            var found = await _context.Rooms.FindAsync(id);

            if (found != null)
            {
                if (model.StatusRoom == StatusRoom.Used)
                {
                    if (string.IsNullOrEmpty(model.Phone))
                    {
                        ModelState.AddModelError(string.Empty, "Số điện thoại không được bỏ trống");
                    }
                    if (string.IsNullOrEmpty(model.Name))
                    {
                        ModelState.AddModelError(string.Empty, "Tên khách hàng không được bỏ trống");
                    }
                    if (string.IsNullOrEmpty(model.Phone))
                    {
                        ModelState.AddModelError(string.Empty, "CMND không được bỏ trống");
                    }
                    if (string.IsNullOrEmpty(model.Address))
                    {
                        ModelState.AddModelError(string.Empty, "Địa chỉ không được bỏ trống");
                    }
                    if (string.IsNullOrEmpty(Request.Form["TimeBook"]))
                    {
                        ModelState.AddModelError(string.Empty, "Thời gian đặt không được bỏ trống");
                    }

                    found.Name = model.Name;
                    found.Phone = model.Phone;
                    found.IdentityCard = model.IdentityCard;
                    found.Address = model.Address;
                    found.StatusRoom = model.StatusRoom;
                    found.TimeBook = model.TimeBook;
                    found.Note = model.Note;
                    found.UpdatedAt = DateTime.Now;
                    ViewBag.TypeRoom = await _context.TypeRooms.ToListAsync();
                    await _context.SaveChangesAsync();


                    // add customer 

                    var foundCustomer = await _context.Customers.Where(item => item.Phone == model.Phone).FirstOrDefaultAsync();
                    if (foundCustomer == null)
                    {
                        foundCustomer = new Customer
                        {
                            Name      = Request.Form["FullName"],
                            Phone     = Request.Form["Phone"],
                            Email     = Request.Form["Email"],
                            CreatedAt = DateTime.Now,
                            Avatar    = "/uploads/avatar-customer.jpg",
                            BookCount = 1
                        };

                        await _context.Customers.AddAsync(foundCustomer);
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        foundCustomer.BookCount += 1;
                        await _context.SaveChangesAsync();
                    }


                    return View("/Views/Admin/Room/Detail.cshtml", found);
                }
                else
                {
                    found.Name         = "";
                    found.Phone        = "";
                    found.IdentityCard = "";
                    found.Address      = "";
                    found.Note         = "";
                    found.TimeBook     = null;
                    found.StatusRoom   = model.StatusRoom;
                }

                await _context.SaveChangesAsync();
                return Redirect("/admin/room/" + id);

            }


            return Ok(1);
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
                                    RoomId = item.RoomId,
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