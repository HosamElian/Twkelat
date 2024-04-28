using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twkelat.Persistence.DTOs
{
    public class ChangeValidState
    {
        public int Id { get; set; }
        public bool State { get; set; }
        public DateTime ExpirationDate { get; set; }

    }
}
