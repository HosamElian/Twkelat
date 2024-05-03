using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twkelat.Persistence.DTOs
{
	public class ChangeCodeRequestDTO
	{
        public string CivilId { get; set; }
        public string OldCode { get; set; }
		public string NewCode { get; set; }
	}
}
