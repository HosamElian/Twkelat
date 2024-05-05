using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twkelat.Persistence.DTOs;
using Twkelat.Persistence.Models;

namespace Twkelat.Persistence.Interfaces.IRepository
{
    public interface ITwkelateRepository
    {
        Block? GetTwkelatBlockById(int id); 
        //IEnumerable<Block> GetAll();
        IEnumerable<Block> GetAll(bool admin, string civilId);
		void AddBlcok(Block blcok);
        bool UpdateBlcok(ChangeValidState model);
        Block? GetLastBlcok();
        void AddUserTempCode(UsersTempCode usersTempCode);
        string GetUserTempCode(string CivilID);

	}
}
