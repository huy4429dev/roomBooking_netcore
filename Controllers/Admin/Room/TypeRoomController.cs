using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RoomBooking.Data;

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
        public  async Task<IActionResult> Index()
        {
            var query = _context.TypeRooms.AsQueryable();
            var data = await query.OrderByDescending(item => item.Id).ToListAsync();
            return View("/Views/Admin/Room/TypeRoom.cshtml",data);
        }
    }
}