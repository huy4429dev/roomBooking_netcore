using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RoomBooking.Data;
using RoomBooking.Models;

namespace RoomBooking.Controllers
{
    [Route("admin/room/type")]
    [Authorize(Roles = "Admin")]
    public class TypeRoomController : Controller
    {
        private ApplicationDbContext _context;

        public TypeRoomController(
            ApplicationDbContext context
        )
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var query = _context.TypeRooms.AsQueryable();
            var data = await query.OrderByDescending(item => item.Id).ToListAsync();
            ViewBag.msg = ViewBag.msgDelete;
            return View("/Views/Admin/Room/TypeRoom.cshtml", data);
        }

        [HttpGet("create")]
        public async Task<IActionResult> Create()
        {

            ViewBag.services = await _context.Services.ToListAsync();
            return View("/Views/Admin/Room/TypeRoomCreate.cshtml");
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromForm] TypeRoom model)
        {

            ViewBag.services = await _context.Services.ToListAsync();

            if (model.Price.ToString() == "0")
            {

                ModelState.AddModelError(string.Empty, "Vui lòng chọn mức giá");
                return View("/Views/Admin/Room/TypeRoomCreate.cshtml");

            }

            if (ModelState.IsValid)
            {

                model.CreatedAt = DateTime.Now;
                model.Rate = 5;
                await _context.TypeRooms.AddAsync(model);
                await _context.SaveChangesAsync();
                ViewBag.message = "Thêm loại phòng thành công";
                ModelState.Clear();
                return View("/Views/Admin/Room/TypeRoomCreate.cshtml");

            }

            return View("/Views/Admin/Room/TypeRoomCreate.cshtml");
        }

        [HttpGet("detail/{id}")]
        public async Task<IActionResult> Detail(int id)
        {

            ViewBag.services = await _context.Services.ToListAsync();
            var typeRoom = await _context.TypeRooms.Where(item => item.Id == id)
                                     .Select(item => new TypeRoom
                                     {
                                         Id = item.Id,
                                         Name = item.Name,
                                         Description = item.Description,
                                         Thumbnail = item.Thumbnail,
                                         CreatedAt = item.CreatedAt,
                                         Price = item.Price,
                                         TypeRoomServices = item.TypeRoomServices
                                     })
                                     .FirstOrDefaultAsync();

            return View("/Views/Admin/Room/TypeRoomDetail.cshtml", typeRoom);


        }


        [HttpPost("update/{id}")]
        public async Task<IActionResult> Update([FromForm] TypeRoom model, int id)
        {
            
                
            ViewBag.services = await _context.Services.ToListAsync();

            if (model.Price.ToString() == "0")
            {

                ModelState.AddModelError(string.Empty, "Vui lòng chọn mức giá");
                return View("/Views/Admin/Room/TypeRoomCreate.cshtml");

            }

            if (ModelState.IsValid)
            {

                var found = await _context.TypeRooms.FindAsync(id);
                if (found != null)
                {
                    found.Name = model.Name;
                    found.Description = model.Description;
                    found.Price = model.Price;
                    found.Thumbnail = model.Thumbnail;

                    var roomServices = _context.RoomServices.Where(item => item.TypeRoomId == found.Id);

                    foreach (var item in roomServices)
                    {
                        _context.RoomServices.Remove(item);
                    }

                    await _context.SaveChangesAsync();

                    found.TypeRoomServices = model.TypeRoomServices;
                    await _context.SaveChangesAsync();

                    ViewBag.message = "Cập nhật loại phòng thành công";
                    

                    return Redirect("/admin/room/type/detail/" + id);

                }

                return BadRequest("Không tồn tại loại phòng");

            }

            return View("/Views/Admin/Room/TypeRoomDetail.cshtml");
        }

        [HttpGet("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            var room = await _context.Rooms.Where(item => item.TypeRoomId == id).ToListAsync();
            if (room.Count == 0)
            {
                var typeRoom = await _context.TypeRooms.FindAsync(id);
                if (typeRoom != null)
                {
                    _context.TypeRooms.Remove(typeRoom);
                    await _context.SaveChangesAsync();
                    ViewBag.msgDelete = "Xóa loại phòng thành công";
                     return Redirect("/admin/room/type");
                }

                return BadRequest("Không tồn tại công việc");

            }
            return Redirect("/admin/room/type");
        }
    }
}