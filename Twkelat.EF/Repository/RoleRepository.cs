using Microsoft.EntityFrameworkCore;
using Twkelat.Persistence.Interfaces.IRepository;

namespace Twkelat.EF.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ApplicationDbContext _context;

        public RoleRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<string>> GetAllAsync()
        {
            var roles = await _context.Roles.AsQueryable().ToListAsync();
            return roles.Select(x => x.Name).ToList();
        }
    }
}
