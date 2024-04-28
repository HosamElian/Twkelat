using System.ComponentModel.DataAnnotations;

namespace Twkelat.Persistence.NotDbModels
{
    public class LoginModel
    {
        [Required]
        public string CivilId { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
