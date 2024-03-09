using Microsoft.AspNetCore.Identity;

namespace Twkelat.Persistence.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Image { get; set; }
    }
}
