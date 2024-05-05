using Twkelat.Persistence.DTOs;
using Twkelat.Persistence.NotDbModels;

namespace Twkelat.Persistence.Interfaces.IServices
{
    public interface IAuthService
    {
        Task<AuthModelResponse> RegisterAsync(RegisterModel registerModel);
        Task<AuthModelResponse> Login(LoginModel tokenRequestModel);
        Task<string> AddRoleAsync(AddRoleModel addRoleModel);
        Task<bool> CheckRequest(CheckRequestDTO checkRequest);
        Task<bool> ChangePassword(ChangeCodeRequestDTO codeRequest);
		Task<bool> GenerateCodeRequest(string civilId);
	}
}
