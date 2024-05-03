using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System.Reflection;
using System.Text;
using Twkelat.Persistence;
using Twkelat.Persistence.BlockExtension;
using Twkelat.Persistence.Consts;
using Twkelat.Persistence.DTOs;
using Twkelat.Persistence.Interfaces.IRepository;
using Twkelat.Persistence.Interfaces.IServices;
using Twkelat.Persistence.Models;
using Twkelat.Persistence.NotDbModels;

namespace Twkelat.BusinessLogic.Services
{
    public class TwkelatService : ITwkelatService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
		private readonly UserManager<ApplicationUser> _userManager;

		public TwkelatService(IUnitOfWork unitOfWork,
            IMapper mapper,
            UserManager<ApplicationUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
			_userManager = userManager;
		}
        public Result AddNewBlock(CreateBlockDTO model)
        {
            Block block = new();
            ApplicationUser userFor = _unitOfWork.User.GetbyCivilIdAsync(model.CreateForCivilId).Result;
            ApplicationUser userBy = _unitOfWork.User.GetbyCivilIdAsync(model.CreateByCivilId).Result;
            var lastIndex = _unitOfWork.TwkelateChain.GetLastBlcok();
            if (lastIndex == null)
            {

                block.Nonce = 1;
                block.PrevHash = [0x01];
            }
            else
            {
                block.Nonce = lastIndex.Nonce++;
                block.PrevHash = lastIndex.Hash;
            }
            block.TimeStamp = DateTime.Now;
            block.CreateByCivilId = model.CreateByCivilId;
            block.CreateForCivilId = model.CreateForCivilId;
            block.CreateForId = userFor.Id;
            block.CreateById = userBy.Id;
            block.Active = true;
            block.ExpirationDate = model.ExpirationDate;
            block.Scope = model.Scope;
            block.PowerAttorneyTypeId = model.PowerAttorneyTypeId;
            block.TempleteId = model.TempleteId;
            block.Hash = block.GenerateHash();

            _unitOfWork.TwkelateChain.AddBlcok(block);
            var res =  _unitOfWork.Save().Result;
            if (res)
            {
                return new Result
                {
                    IsCompleted = true,
                    Message = ResultMessages.ProcessCompleted,
                };
            }
            return new Result();
        }

        public Result ChangeBlockValidState(ChangeValidState model)
        {
            var changed = _unitOfWork.TwkelateChain.UpdateBlcok(model);

            if (!changed) return new Result();

            return new Result() { IsCompleted = true, Message = ResultMessages.ProcessCompleted };
        }

        public Result GetAllBlcoksAsync(string civilId)
		{
            var isAdmin = false;
            var user = _unitOfWork.User.GetbyCivilIdAsync(civilId).Result;
            var userRoles = _userManager.GetRolesAsync(user).GetAwaiter().GetResult();

			if (userRoles.Contains(SD.Role_Admin))
            {
                isAdmin = true;
            }
			var chain = _unitOfWork.TwkelateChain.GetAll(isAdmin, civilId);
            if (!chain.Any()) return new Result() { Message = ResultMessages.NoBlocksFound};
            var data = chain.Select(c => new DelegationDTO
            {
                CommissionerName = c.CreatedFor?.Name ?? "Name",
                ExpirationDate = c.ExpirationDate,
                ExpirationDateAsString = c.ExpirationDate.ToString("dd/MM/yyyy"),
                Hash = c.Hash,
                Id = c.Id,
                TempleteName = c.Templete.Name ?? "Public",
                FromMe = (c.CreateByCivilId == civilId)
            });
            return new Result
            {
                IsCompleted = true,
                Message = ResultMessages.ProcessCompleted,
                Value = data

            };
        }
        public Result GetBlcokByIdAsync(int id)
        {
            var chain = _unitOfWork.TwkelateChain.GetTwkelatBlockById(id);
            if (chain == null) return new Result() { Message = ResultMessages.NoBlocksFound };
             
            var data = new DelegationVMDTO
            {
                CommissionerName = chain.CreatedFor?.Name ?? "Name",
                ExpirationDate = chain.ExpirationDate,
                ExpirationDateAsString = chain.ExpirationDate.ToString("dd/MM/yyyy"),
				Hash = chain.Hash,
                Id = chain.Id,
                TempleteName = chain.Templete.Name ?? "Temp",
                FromMe = true,
            };
            return new Result
            {
                IsCompleted = true,
                Message = ResultMessages.ProcessCompleted,
                Value = data
            };
        }
    }
}
