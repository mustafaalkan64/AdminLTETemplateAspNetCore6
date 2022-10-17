using System.ComponentModel.DataAnnotations;

namespace KaracadanWebApp.Models
{
    public class UserLoginModel
    {
        public bool RememberMe { get; set; }

        [EmailAddress(ErrorMessage = "Lütfen Geçerli Bir Email Giriniz")]
        [Required(ErrorMessage = "Email Alanı Zorunludur")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Lütfen Şifre Giriniz")]
        public string Password { get; set; }
    }
}
