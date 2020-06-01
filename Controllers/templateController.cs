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
    public class TemplateController : Controller
    {
        private ApplicationDbContext _context;

        public TemplateController(
            ApplicationDbContext context
        )
        {
            _context = context;
        }
      
    }
}