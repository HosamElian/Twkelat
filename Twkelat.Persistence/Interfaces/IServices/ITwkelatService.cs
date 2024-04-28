using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twkelat.Persistence.DTOs;
using Twkelat.Persistence.NotDbModels;

namespace Twkelat.Persistence.Interfaces.IServices
{
    public interface ITwkelatService
    {
        Result GetBlcokByIdAsync(int id);
        Result GetAllBlcoksAsync(string civilId);
        Result AddNewBlock(CreateBlockDTO model);
        Result ChangeBlockValidState(ChangeValidState model);
    }
}
