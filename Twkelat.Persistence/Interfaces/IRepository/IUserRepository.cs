using Twkelat.Persistence.DTOs;
using Twkelat.Persistence.Models;

namespace Twkelat.Persistence.Interfaces.IRepository
{
    public interface IUserRepository
    {
        Task<IEnumerable<ApplicationUser>> GetAllAsync();
        Task<IEnumerable<UserFroSearchDTO>> GetbyUsernameAsync(string username);

    }
}
