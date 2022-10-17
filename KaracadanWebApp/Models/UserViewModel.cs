using System.ComponentModel.DataAnnotations;

namespace KaracadanWebApp.Models
{
    public class UserViewModel
    {
        [Required(ErrorMessage = "Kullanıcı ismi gerekldir.")]
        [Display(Name = "Kullanıcı Adı")]
        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Display(Name = "Tel No:")]
        //[RegularExpression(@"^(0(\d{3}) (\d{3}) (\d{2}) (\d{2}))$", ErrorMessage = "Telefon numarası uygun formatta değil")]
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
