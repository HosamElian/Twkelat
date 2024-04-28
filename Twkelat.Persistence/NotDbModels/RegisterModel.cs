using System.ComponentModel.DataAnnotations;

namespace Twkelat.Persistence.NotDbModels
{
    public class RegisterModel
    {
        [Required]
        public string CivilId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
