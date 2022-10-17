using System.ComponentModel.DataAnnotations;

namespace KaracadanWebApp.Models
{
    public class UserViewModel
    {
        [Required(ErrorMessage = "Kullanıcı ismi gereklidir.")]
        [Display(Name = "Kullanıcı Adı")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "İsim gereklidir.")]
        [Display(Name = "İsim")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Soyisim gereklidir.")]
        [Display(Name = "Soyisim")]
        public string LastName { get; set; }

        [Display(Name = "Tel No:")]
        //[RegularExpression(@"^(0(\d{3}) (\d{3}) (\d{2}) (\d{2}))$", ErrorMessage = "Telefon numarası uygun formatta değil")]
        [Required(ErrorMessage = "Telefon Numarası gereklidir.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email adresi gereklidir.")]
        [Display(Name = "Email Adresiniz")]
        [EmailAddress(ErrorMessage = "Email adresiniz doğru formatta değil")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifreniz gereklidir.")]
        [Display(Name = "Şifre")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
