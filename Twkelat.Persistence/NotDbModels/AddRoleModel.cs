using System.ComponentModel.DataAnnotations;

namespace Twkelat.Persistence.NotDbModels
{
    public class AddRoleModel
    {
        [Required]
        public string UserId { get; set; }
        [Required]
        public string Role { get; set; }
    }
}
