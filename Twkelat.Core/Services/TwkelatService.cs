using AutoMapper;
using System.Text;
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

        public TwkelatService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
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
            var chain = _unitOfWork.TwkelateChain.GetAll();
            if (!chain.Any()) return new Result() { Message = ResultMessages.NoBlocksFound};
            var data = chain.Select(c => new DelegationDTO
            {
                CommissionerName = c.CreatedFor?.FirstName ?? "Name",
                ExpirationDate = c.ExpirationDate,
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
                CommissionerName = chain.CreatedFor?.FirstName ?? "Name",
                ExpirationDate = chain.ExpirationDate,
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
