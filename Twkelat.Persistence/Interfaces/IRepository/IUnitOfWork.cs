namespace Twkelat.Persistence.Interfaces.IRepository
{
    public interface IUnitOfWork
    {
        IRoleRepository Role { get; }
        IUserRepository User { get; }
        ITwkelateRepository TwkelateChain { get; }

        Task<bool> Save();
    }
}
