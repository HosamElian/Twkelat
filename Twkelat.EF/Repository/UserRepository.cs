using Microsoft.EntityFrameworkCore;
using Twkelat.Persistence.DTOs;
using Twkelat.Persistence.Models;
using Twkelat.Persistence.Interfaces.IRepository;

namespace Twkelat.EF.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ApplicationUser>> GetAllAsync()
        {
            return (IEnumerable<ApplicationUser>)await _context.Users.AsQueryable().AsNoTracking().ToListAsync();

        }

        public async Task<IEnumerable<UserFroSearchDTO>> GetbyUsernameAsync(string username)
        {
            return await _context.Users.AsQueryable().AsNoTracking()
                .Where(x => x.UserName.Contains(username))
                .Select(u => new UserFroSearchDTO { Name = u.UserName })
                .ToListAsync();
        }
    }
}
