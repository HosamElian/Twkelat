using Twkelat.Persistence.Interfaces.IRepository;

namespace Twkelat.EF.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            RoleRepository = new RoleRepository(context);
            UserRepository = new UserRepository(context);
            _context = context;
        }

        public IRoleRepository RoleRepository { get; private set; }

        public IUserRepository UserRepository { get; private set; }


        public async Task<bool> Save()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
