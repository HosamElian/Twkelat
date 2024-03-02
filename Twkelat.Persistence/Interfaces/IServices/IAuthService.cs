using Twkelat.Persistence.NotDbModels;

namespace Twkelat.Persistence.Interfaces.IServices
{
    public interface IAuthService
    {
        Task<AuthModelResponse> RegisterAsync(RegisterModel registerModel);
        Task<AuthModelResponse> GetTokenAsync(TokenRequestModel tokenRequestModel);
        Task<string> AddRoleAsync(AddRoleModel addRoleModel);
    }
}
