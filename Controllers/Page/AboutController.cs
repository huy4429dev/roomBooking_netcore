using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RoomBooking.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace RoomBooking.Page.Controllers
{
    [Route("/gioi-thieu")]
    public class AboutController : Controller
    {
        private ApplicationDbContext _context;

        public AboutController(
            ApplicationDbContext context
        )
        {
            _context = context;
        }
      
        [HttpGet]
        public IActionResult Index(){
            return View();
        }
    }
}