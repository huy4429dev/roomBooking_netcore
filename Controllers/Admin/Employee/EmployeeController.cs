
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

    [Route("admin/employee/")]
    [Authorize(Roles = "Admin")]
    public class EmployeeController : Controller
    {
        private ApplicationDbContext _ctx;

        public EmployeeController(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {

            var query = _ctx.Employees.AsQueryable();
            var data = await query.OrderByDescending(item => item.Id).ToListAsync();
            return View("Views/Admin/Employee/Index.cshtml", data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int Id, Employee model){
            var Employee = await _ctx.Employees.FindAsync(Id);
            if(Employee != null){
                var query = _ctx.Employees.Where(item => item.Id == Id)
                                          .Select(item => new {
                                              item,
                                          });
                var data  =  await query.FirstAsync();
                return Ok(data);    
            }
            return BadRequest("Không tồn tại nhân viên");
        }

        [HttpGet("create")]
        public IActionResult Create()
        {
            return View("Views/Admin/Employee/Create.cshtml");
        }

        [HttpPost("create")]

        public  async Task<IActionResult> Create([FromForm] Employee model)
        {
            if(ModelState.IsValid){
                
                var Employee = new Employee {
                    FullName    = model.FullName,
                    Email       = model.Email,
                    Phone       = model.Phone,
                    Address     = model.Address,
                    YearOfBirth = model.YearOfBirth,
                    Position    = model.Position,
                    Avatar      = "/uploads/employee-avatar637263828282866486.png",
                    CreatedAt   = DateTime.Now
                };
                await _ctx.Employees.AddAsync(Employee);
                await _ctx.SaveChangesAsync();
                ViewBag.message = "Thêm nhân viên thành công";
                ModelState.Clear();
            }
            return View("Views/Admin/Employee/Create.cshtml");
        }



    }
}