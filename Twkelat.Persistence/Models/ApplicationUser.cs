using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Twkelat.Persistence.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? Name { get; set; }
        public string? Image { get; set; }
        [Key]
        public string CivilId { get; set; }
    }
}
