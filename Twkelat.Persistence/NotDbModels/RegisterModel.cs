using System.ComponentModel.DataAnnotations;

namespace Twkelat.Persistence.NotDbModels
{
    public class RegisterModel
    {
        [Required]
        public string Password { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Username { get; set; }

    }
}
