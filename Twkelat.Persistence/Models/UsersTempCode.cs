using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twkelat.Persistence.Models
{
	public class UsersTempCode
	{
        public int Id { get; set; }
        public string CivilID { get; set; }
        public bool IsDeleted { get; set; }
        public string Key { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
