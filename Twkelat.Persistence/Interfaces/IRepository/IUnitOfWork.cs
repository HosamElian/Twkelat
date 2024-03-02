namespace Twkelat.Persistence.Interfaces.IRepository
{
    public interface IUnitOfWork
    {
        IRoleRepository RoleRepository { get; }
        IUserRepository UserRepository { get; }

        Task<bool> Save();
    }
}
