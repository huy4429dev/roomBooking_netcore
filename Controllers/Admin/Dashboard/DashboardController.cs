using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RoomBooking.Controllers
{
    [Route("admin/dashboard")]
    [Authorize(Roles = "Admin")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View("/Views/Admin/Dashboard/Index.cshtml");
        }
    }
}