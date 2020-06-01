
using System.Threading.Tasks;
using RoomBooking.Models;
using RoomBooking.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using RoomBooking.Data;
using System;
using System.IO;
using System.Net.Http.Headers;

namespace CarBooking.Controllers
{
    [Route("admin")]
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private RoleManager<ApplicationRole> _roleManager;
        private SignInManager<ApplicationUser> _signInManager;
        private ApplicationDbContext _context;

        public AccountController(

            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager,
            SignInManager<ApplicationUser> signInManager,
            ApplicationDbContext context
        )
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _context = context;
        }

        // [HttpGet]
        // public IActionResult Register()
        // {
        //     return View();
        // }

        // [HttpPost]
        // public async Task<IActionResult> Register([FromForm] RegisterViewModel model)
        // {
        //     if (ModelState.IsValid)
        //     {
        //         var User = new ApplicationUser
        //         {
        //             FullName = model.FullName,
        //             Email = model.Email,
        //             UserName = model.UserName
        //         };

        //         var result = await _userManager.CreateAsync(User, model.Password);

        //         if (result.Succeeded)
        //         {

        //             var roleUser = await _roleManager.FindByIdAsync("3");
        //             await _userManager.AddToRoleAsync(User, roleUser.Name);

        //             await _signInManager.SignInAsync(User, isPersistent: false);
        //             return RedirectToAction("index", "home");
        //         }


        //         foreach (var error in result.Errors)
        //         {
        //             ModelState.AddModelError("", error.Description);
        //         }

        //     }
        //     return View(model);
        // }

        [HttpGet("login")]
        public IActionResult LogIn()
        {
            return View("/Views/Admin/Account/Login.cshtml");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromForm] LoginViewModel model)
        {

            if (ModelState.IsValid)
            {

                var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    else
                    {

                        return RedirectToAction("Index", "Dashboard");
                    }
                }
                ModelState.AddModelError(string.Empty, "Sai tên đăng nhập hoặc mật khẩu");

            }

            return View("/Views/Admin/Account/Login.cshtml", model);
        }



        [HttpPost]
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Admin");
        }

        [Route("make-role")]
        public async Task<IActionResult> makeRole()
        {
            var adminRole = new ApplicationRole
            {
                Name = "Admin"
            };


            await _roleManager.CreateAsync(adminRole);

            var staffRole = new ApplicationRole
            {
                Name = "System staff"
            };

            await _roleManager.CreateAsync(staffRole);

            return Ok("Tạo vai trò thành công");
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetRole()
        {
            var roleUser = await _roleManager.FindByIdAsync("1");
            return Ok(roleUser);
        }
        [Route("make-admin")]

        public async Task<IActionResult> makeAdmin()
        {

            var User = new ApplicationUser
            {
                FullName = "admin",
                Email = "admin@gmail.com",
                UserName = "admin"
            };

            var result = await _userManager.CreateAsync(User, "123456");
            var roleUser = await _roleManager.FindByIdAsync("1");
            await _userManager.AddToRoleAsync(User, roleUser.Name);
            return Ok("Tạo admin thành công");
        }

        [HttpGet("profile")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Profile()
        {

            var    userId    = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var    user      = await _context.Users.FindAsync(Int32.Parse(userId));
            var    rolenames = await _userManager.GetRolesAsync(user);
            string rolename  = rolenames[0];
            return View("Views/Admin/Account/Profile.cshtml", user);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("profile")]
        public async Task<IActionResult> Profile([FromForm] ApplicationUser model)
        {

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _context.Users.FindAsync(Int32.Parse(userId));
            if (ModelState.IsValid)
            {

                user.FullName = model.FullName;
                user.PhoneNumber = model.PhoneNumber;
                if (user.Email != model.Email)
                {
                    user.Email = model.Email;
                }

                if (!string.IsNullOrEmpty(model.Password))
                {
                    var newPassword = _userManager.PasswordHasher.HashPassword(user, model.Password);
                    user.PasswordHash = newPassword;
                }
                var res = await _userManager.UpdateAsync(user);
            }

            return View("Views/Admin/Account/Profile.cshtml", user);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("update-avatar"), DisableRequestSizeLimit]
        public async Task<IActionResult> UpdateAvatar()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _context.Users.FindAsync(Int32.Parse(userId));
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
                    
                    user.Avatar = dbPath;
                    await _context.SaveChangesAsync();

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


    }
}