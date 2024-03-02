using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twkelat.Persistence.Models
{
    public class Delegation
    {
        public int Id { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public ApplicationUser CreatedBy { get; set; }
        public ApplicationUser UpdatedBy { get; set; }
        public Document Document { get; set; }
        public ApplicationUser Client { get; set; }
        public ApplicationUser Agent { get; set; }
        public bool IsValid { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
