using System.ComponentModel.DataAnnotations;

namespace KaracadanWebApp.Models
{
    public class UserLoginModel
    {
        //public string UserName { get; set; }

        public string Password { get; set; }
        public bool RememberMe { get; set; }

        [DataType(DataType.EmailAddress, ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }
    }
}
