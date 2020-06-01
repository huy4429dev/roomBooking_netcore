using System;
using System.ComponentModel.DataAnnotations;

namespace RoomBooking.ViewModels
{
    public class LoginViewModel
    {

        [Required(ErrorMessage = "Vui lòng nhập tài khoản")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string ReturnUrl {set;get;}
        
        [Display(Name = "Ghi nhớ đăng nhập")] 
        public bool RememberMe {get;set;}


    }
}