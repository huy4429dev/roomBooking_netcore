using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RoomBooking.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

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
        public  async Task<IActionResult> Index()
        {
            var rooms = await _context.Rooms.ToListAsync();
            return View("/Views/Admin/Room/Index.cshtml",rooms);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> detail(int id){
            var room = await  _context.Rooms.FindAsync(id);

            if(room != null){
                  return View("/Views/Admin/Room/Detail.cshtml",room);
            }
            return BadRequest("Không tồn tại phòng");
        }
    }
}