using Twkelat.Persistence.Consts;
using Twkelat.Persistence.Interfaces.IRepository;
using Twkelat.Persistence.Interfaces.IServices;
using Twkelat.Persistence.NotDbModels;

namespace Twkelat.BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Result> GetUsers(string username)
        {

            var usersFromDb = await _unitOfWork.User.GetbyUsernameAsync(username);
            if (usersFromDb is not null)
            {

                return new Result() { IsCompleted = true, Message = ResultMessages.ProcessCompleted, Value = usersFromDb };
            }
            return new Result() { Message = ResultMessages.NoUserFound };
        }
    }
}
