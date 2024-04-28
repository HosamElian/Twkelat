using System.ComponentModel.DataAnnotations.Schema;
using Twkelat.Persistence.BlockExtension;

namespace Twkelat.Persistence.Models
{
    public class Block : IBlock
    {
        public int Id { get; set; }
        public bool Active { get; set; }
        public byte[] Hash { get; set; }
        public byte[] PrevHash { get; set; }
        public int Nonce { get; set; }
        public int? TempleteId { get; set; }
        public int PowerAttorneyTypeId { get; set; }
        public string CreateForId { get; set; }
        public string CreateById { get; set; }
        public string Scope { get; set; }
        public string CreateForCivilId { get; set; }
        public string CreateByCivilId { get; set; }

        public DateTime TimeStamp { get; set; } = DateTime.Now;
        public DateTime ExpirationDate { get; set; }
        [ForeignKey(nameof(CreateById))]
        public ApplicationUser? CreatedBy { get; set; }
        [ForeignKey(nameof(CreateForId))]
        public ApplicationUser? CreatedFor { get; set; }
        [ForeignKey(nameof(TempleteId))]
        public Templete? Templete { get; set; }
        [ForeignKey(nameof(PowerAttorneyTypeId))]
        public PowerAttorneyType? PowerAttorneyType { get; set; }


    }
}
