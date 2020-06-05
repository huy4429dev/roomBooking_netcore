using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RoomBooking.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using RoomBooking.Models;
using RoomBooking.ViewModels;

namespace RoomBooking.Page.Controllers
{
    [Route("/tin-tuc")]
    public class BlogController : Controller
    {
        private ApplicationDbContext _context;

        public BlogController(
            ApplicationDbContext context
        )
        {
            _context = context;
        }
      
        [HttpGet]
        public async Task<IActionResult> Index(){

            var News = await _context.BlogPosts.OrderByDescending(item => item.Id)
                            .Select(item => new BlogPost{
                                Title = item.Title,
                                Thumbnail = item.Thumbnail,
                                Description = item.Description,
                                User = item.User, 
                                CreatedAt = item.CreatedAt
                            })
                            .Take(3)
                            .ToListAsync();

            ViewBag.RecentPost = await _context.BlogPosts.OrderByDescending(item => item.Id)
                            .Select(item => new RecentPostViewModel{
                                Title = item.Title,
                                Thumbnail = item.Thumbnail,
                                CategoryName = item.PostCategories.Select(ct => ct.Category.Name).FirstOrDefault(),
                                CreatedAt = item.CreatedAt
                            })
                            .Take(3)
                            .ToListAsync();

            ViewBag.Categories = await _context.BlogCategories
                                .Select(item => new BlogCategory {
                                    Name = item.Name,
                                    PostCategories = item.PostCategories
                                })
                                .ToListAsync();
            return View(News);
        }
    }
}