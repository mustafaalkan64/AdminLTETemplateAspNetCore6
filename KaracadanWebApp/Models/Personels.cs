using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace KaracadanWebApp.Models
{
    public class Personels
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "İsim Alanı Zorunludur")]
        [StringLength(100, ErrorMessage = "İsim En Fazla 100 Karakter Olabilir")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Soyisim Alanı Zorunludur")]
        [StringLength(100, ErrorMessage = "Soyisim En Fazla 100 Karakter Olabilir")]

        public string Surname { get; set; }
        
        [StringLength(100, ErrorMessage = "Email Alanı En Fazla 100 Karakter Olabilir")]
        [EmailAddress(ErrorMessage = "Email Formatını Doğru Giriniz")]
        [Required(ErrorMessage = "Email Alanı Zorunludur")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Şifre Alanı Zorunludur")]
        public string Password { get; set; }
        
        [StringLength(100, ErrorMessage = "Telefon Numarası En Fazla 100 Karakter Olabilir")]
        public string PhoneNumber { get; set; }
        
        [StringLength(100, ErrorMessage = "Kart Numarası En Fazla 100 Karakter Olabilir")]
        public string CardNumber { get; set; }
        [StringLength(100, ErrorMessage = "Firma Adı Alanı En Fazla 100 Karakter Olabilir")]
        public string FirmName { get; set; }
        
        [StringLength(100, ErrorMessage = "Sicil No Alanı En Fazla 100 Karakter Olabilir")]
        public string SicilNo { get; set; }
    }
}
