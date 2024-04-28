using Twkelat.Persistence.Interfaces.IRepository;

namespace Twkelat.EF.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            Role = new RoleRepository(context);
            User = new UserRepository(context);
            TwkelateChain = new TwkelateRepository(context);
            _context = context;
        }

        public IRoleRepository Role { get; private set; }

        public IUserRepository User { get; private set; }
        public ITwkelateRepository TwkelateChain { get; private set; }


        public async Task<bool> Save()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
