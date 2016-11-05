using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JCleanLaundry.Models
{

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Nama akun")]
        public string Username { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Nama akun")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Kata sandi")]
        public string Password { get; set; }

        [Display(Name = "Ingatkan saya?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Nama akun")]
        public string Username { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Kata sandi")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Ulangi kata sandi")]
        [Compare("Password", ErrorMessage = "Kata sandi dan ulangi kata sandi tidak sama.")]
        public string ConfirmPassword { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [Display(Name = "Nama akun")]
        public string Username { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "Kata sandi dan ulangi kata sandi tidak sama.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [Display(Name = "Nama akun")]
        public string Username { get; set; }
    }
}
