using System.ComponentModel.DataAnnotations;

namespace Twkelat.Persistence.NotDbModels
{
    public class RegisterModel
    {
        [Required]
        public string CivilId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
