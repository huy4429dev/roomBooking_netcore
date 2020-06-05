using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RoomBooking.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using RoomBooking.Models;
using System;

namespace RoomBooking.Page.Controllers
{
    [Route("/lien-he")]
    public class ContactController : Controller
    {
        private ApplicationDbContext _context;

        public ContactController(
            ApplicationDbContext context
        )
        {
            _context = context;
        }
      
        [HttpGet]
        public IActionResult Index(){
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] Contact model)
        {


            if (ModelState.IsValid)
            {

                var Contact = new Contact
                {
                    Name = model.Name,
                    Email = model.Email,
                    Phone = model.Phone,
                    Subject = model.Subject,
                    Content = model.Content,
                    Status = false,
                    CreatedAt = DateTime.Now
                };

                await _context.Contacts.AddAsync(Contact);
                await _context.SaveChangesAsync();
                ViewBag.message = "Gửi liên hệ thành công";
                ModelState.Clear();
                return View("/Views/Contact/Index.cshtml");

            }
            return View("/Views/Contact/Index.cshtml");
        }
    }
}