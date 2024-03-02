using Twkelat.Persistence.NotDbModels;

namespace Twkelat.Persistence.Interfaces.IServices
{
    public interface IUserService
    {
        Task<Result> GetUsers(string username);
    }
}
