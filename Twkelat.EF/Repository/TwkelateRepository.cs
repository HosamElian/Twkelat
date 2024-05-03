using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twkelat.Persistence.BlockExtension;
using Twkelat.Persistence.DTOs;
using Twkelat.Persistence.Interfaces.IRepository;
using Twkelat.Persistence.Models;

namespace Twkelat.EF.Repository
{
	public class TwkelateRepository : ITwkelateRepository
    {
        private readonly ApplicationDbContext _context;

        public TwkelateRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void AddBlcok(Block blcok)
        {
            _context.Blocks.Add(blcok);
        }

        public IEnumerable<Block> GetAll()
        {
            return _context.Blocks
                .Include(c=>c.CreatedFor)
                .Include(c => c.CreatedBy)
                .Include(c => c.Templete)
                .Include(c => c.PowerAttorneyType)
                .AsNoTracking()
                .ToList();
        }

		public IEnumerable<Block> GetAll(bool admin, string civilId)
		{
            if (admin)
            {
				return _context.Blocks
			  .Include(c => c.CreatedFor)
			  .Include(c => c.CreatedBy)
			  .Include(c => c.Templete)
			  .Include(c => c.PowerAttorneyType)
			  .AsNoTracking()
			  .ToList();
			}
			return _context.Blocks
                .Where(b=>b.CreateByCivilId.ToLower() == civilId.ToLower() || 
                            b.CreateForCivilId.ToLower() == civilId.ToLower())
			  .Include(c => c.CreatedFor)
			  .Include(c => c.CreatedBy)
			  .Include(c => c.Templete)
			  .Include(c => c.PowerAttorneyType)
			  .AsNoTracking()
			  .ToList();

		}

		public Block? GetLastBlcok()
        {
            return _context.Blocks.OrderBy(c=>c.Nonce).LastOrDefault();
        }

        public Block? GetTwkelatBlockById(int id)
        {
            return _context.Blocks
                .Include(b=>b.CreatedBy)
                .Include(b=>b.CreatedFor)
                .Include(b=>b.Templete)
                .Include(c => c.PowerAttorneyType)
                .FirstOrDefault(b => b.Id == id);
        }

        public bool UpdateBlcok(ChangeValidState model)
        {
            var itemInBlock = _context.Blocks.FirstOrDefault(b=> b.Id == model.Id);
            if (itemInBlock is null) return false;

            itemInBlock.Active = model.State;
            itemInBlock.ExpirationDate = model.ExpirationDate;
            return _context.SaveChanges() > 0;

        }
    }
}
