
using System.Threading.Tasks;
using RoomBooking.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RoomBooking.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace RoomBooking.Admin.Controllers
{

    [Route("admin/customer/")]
    [Authorize(Roles = "Admin")]
    public class CustomerController : Controller
    {
        private ApplicationDbContext _ctx;

        public CustomerController(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {

            var query = _ctx.Customers.AsQueryable();
            var data = await query.OrderByDescending(item => item.Id).ToListAsync();
            return View("Views/Admin/Customer/Index.cshtml", data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int Id, Employee model){
            var Employee = await _ctx.Customers.FindAsync(Id);
            if(Employee != null){
                var query = _ctx.Customers.Where(item => item.Id == Id)
                                          .Select(item => new {
                                              item,
                                          });
                var data  =  await query.FirstAsync();
                return Ok(data);    
            }
            return BadRequest("Không tồn tại nhân viên");
        }

    }
}