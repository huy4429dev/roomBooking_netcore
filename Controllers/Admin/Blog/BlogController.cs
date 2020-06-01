using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RoomBooking.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.IO;
using System;
using System.Net.Http.Headers;
using RoomBooking.Models;
using System.Security.Claims;
using RoomBooking.ViewModels;

namespace RoomBooking.Controllers
{
    [Route("admin/blog")]
    [Authorize(Roles = "Admin")]
    public class BlogController : Controller
    {
        private ApplicationDbContext _context;

        public BlogController(
            ApplicationDbContext context
        )
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var posts = await _context.BlogPosts.OrderByDescending(item => item.Id)
                                .Select(item => new BlogIndexViewModel
                                {
                                    Id = item.Id,
                                    Title = item.Title,
                                    Description = item.Description,
                                    Author = item.User.FullName,
                                    CreatedAt = item.CreatedAt,
                                    Categories = item.PostCategories.Select(cp => new BlogCategory
                                    {
                                        Name = cp.Category.Name
                                    }).ToList()

                                }).ToListAsync();
            return View("Views/Admin/Blog/Index.cshtml", posts);
        }


        [HttpGet("create")]
        public async Task<IActionResult> Create()
        {

            ViewBag.Categories = await _context.BlogCategories.ToListAsync();
            return View("Views/Admin/Blog/Create.cshtml");
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("upload-thumbnail"), DisableRequestSizeLimit]
        public IActionResult UploadThumbnail()
        {
            try
            {

                var file = Request.Form.Files[0];
                var folderName = Path.Combine("wwwroot", "uploads");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (file.Length > 0)
                {
                    var now = DateTime.Now.Ticks.ToString();
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var typeFile = fileName.Substring(fileName.LastIndexOf("."));
                    fileName = fileName.Substring(0, fileName.Length - typeFile.Length) + now + typeFile;
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    dbPath = dbPath.Substring(7);

                    return Ok(new { dbPath });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Internal server errors {e}");
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromForm] BlogPost model)
        {

            if (model.PostCategories.Any(item => item.CategoryId == 0))
            {
                ModelState.AddModelError(string.Empty, "Vui lòng chọn danh mục");
            }

            if (ModelState.IsValid)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                model.UserId = Convert.ToInt32(userId);
                model.CreatedAt = DateTime.Now;
                await _context.BlogPosts.AddAsync(model);
                await _context.SaveChangesAsync();
                return Redirect("/admin/blog");
            }

            ViewBag.Categories = await _context.BlogCategories.ToListAsync();

            return View("Views/Admin/Blog/Create.cshtml");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Detail(int id)
        {

            var post = await _context.BlogPosts.Where(i => i.Id == id).Select(p => new BlogPost
            {
                Id             = p.Id,
                Title          = p.Title,
                Description    = p.Description,
                Content        = p.Content,
                Thumbnail      = p.Thumbnail,
                PostCategories = p.PostCategories,
                CreatedAt      = p.CreatedAt,
                UpdatedAt      = p.UpdatedAt,
                UserId         = p.UserId
            }).FirstAsync();
            if (post != null)
            {
                ViewBag.Categories = await _context.BlogCategories.ToListAsync();
                return View("Views/Admin/Blog/Detail.cshtml", post);
            }

            return BadRequest("Không tồn tại bài viết");

        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Update([FromForm] BlogPost model, int id)
        {

            var post = await _context.BlogPosts.Where(i => i.Id == id).Select(p => new BlogPost
            {
                Id             = p.Id,
                Title          = p.Title,
                Description    = p.Description,
                Content        = p.Content,
                Thumbnail      = p.Thumbnail,
                PostCategories = p.PostCategories,
                CreatedAt      = p.CreatedAt,
                UpdatedAt      = p.UpdatedAt,
                UserId         = p.UserId
            }).FirstAsync();

            //  id not found --> err

            if (post != null)
            {
                ViewBag.Categories = await _context.BlogCategories.ToListAsync();
                if (ModelState.IsValid)
                {
                    post.Title = model.Title;
                    post.Description = model.Description;
                    post.Content = model.Content;
                    post.Thumbnail = model.Thumbnail;
                    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    post.UserId = Convert.ToInt32(userId);
                    post.UpdatedAt = DateTime.Now;
                    await _context.SaveChangesAsync();
                }
                ViewBag.message = "Cập nhật thành công";
                return View("Views/Admin/Blog/Detail.cshtml", post);
            }


            return BadRequest("Không tồn tại bài viết");
        }
    }

}