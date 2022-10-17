using Microsoft.AspNetCore.Identity;

namespace KaracadanWebApp.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
