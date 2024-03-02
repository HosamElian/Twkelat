using Microsoft.AspNetCore.Identity;

namespace Twkelat.Persistence.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Image { get; set; }
    }
}
