using Microsoft.AspNetCore.Mvc;

namespace  RoomBooking.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(){
            return View();
        }
    }
}