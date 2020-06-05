using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RoomBooking.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using RoomBooking.Models;
using RoomBooking.ViewModels;
using System;

namespace RoomBooking.Page.Controllers
{
    [Route("/dat-phong")]
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
        public async Task<IActionResult> Index()
        {
            var typeRooms = await _context.TypeRooms.Where(item => item.Id != 1)
                                          .Select(item => new TypeRoom
                                          {
                                              Id = item.Id,
                                              Name = item.Name,
                                              Price = item.Price,
                                              Description = item.Description,
                                              Thumbnail = item.Thumbnail,
                                              Rate = item.Rate,
                                              TypeRoomServices = item.TypeRoomServices
                                          })
                                          .ToListAsync();
            ViewBag.Services = await _context.Services.Select(
                item => new string[]{
                    item.Name
                }
            ).ToListAsync();
            return View(typeRooms);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BookRoomViewModel model)
        {


            if (!ModelState.IsValid)
            {
                var errors = ModelState.Select(x => x.Value.Errors)
                                    .Where(y => y.Count > 0)
                                    .ToList();
                return BadRequest(errors);
            }

            // add customer 

            var foundCustomer = await _context.Customers.Where(item => item.Phone == model.Phone).FirstOrDefaultAsync();
            if (foundCustomer == null)
            { 
                 foundCustomer = new Customer
                {
                    Name = model.FullName,
                    Phone = model.Phone,
                    Email = model.Email,
                    CreatedAt = DateTime.Now,
                    Avatar = "/uploads/avatar-customer.jpg",
                    BookCount = 1
                };
                
                await _context.Customers.AddAsync(foundCustomer);
                await _context.SaveChangesAsync();
            }


            // add Book Room
        
             var bookRoom = new BookRoom
             {
                 TypeRoomId = model.TypeRoomId,
                 CustomerId = foundCustomer.Id,
                 Status     = false,
                 TimeBook  = (int)model.TimeBook,
                 TimeCreated = model.TimeCreated.HasValue ? model.TimeCreated.Value : DateTime.Now,  
                 CreatedAt  = DateTime.Now,
                 BookRoomStatus = BookRoomStatus.Waiting
             };
             await _context.BookRooms.AddAsync(bookRoom);
             await _context.SaveChangesAsync();


            return Ok(1);
        }
    

    }
}