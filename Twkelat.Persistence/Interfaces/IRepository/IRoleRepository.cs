namespace Twkelat.Persistence.Interfaces.IRepository
{
    public interface IRoleRepository
    {
        Task<IEnumerable<string>> GetAllAsync();

    }
}
