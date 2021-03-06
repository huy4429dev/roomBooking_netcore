using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RoomBooking.Data;

namespace CarBooking.Admin.Controllers{

    [Route("admin/contact/")]
    [Authorize(Roles="Admin")]
    public class ContactController : Controller
    {
        private ApplicationDbContext _ctx;

        public ContactController(ApplicationDbContext ctx)
        {
            _ctx = ctx;    
        }

        [HttpGet]
        public  async Task<IActionResult> Index(){
             
            var data  = await _ctx.Contacts.OrderByDescending(item => item.Id).ToListAsync();
            return View("Views/Admin/Contact/Index.cshtml", data);
        }

        [HttpGet("update-status/{id}")]
        public  async Task<IActionResult> updateStatus(int Id){
        
            var Contact = await _ctx.Contacts.FindAsync(Id);
            if(Contact != null){
                Contact.Status = true;
                await _ctx.SaveChangesAsync();
                return Ok(new {status = true});
            }
            return BadRequest("Không tồn tại liên hệ");
        }

    }
}