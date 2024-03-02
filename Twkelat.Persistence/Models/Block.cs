using Twkelat.Persistence.BlockExtension;

namespace Twkelat.Persistence.Models
{
    public class Block : IBlock
    {

        public int Id { get; set; }
        public ApplicationUser CreatedBy { get; set; }
        public byte[] Data { get; }
        public byte[] Hash { get; set; } 
        public byte[] PrevHash { get; set; }
        public int Nonce { get; set; } 
        public DateTime TimeStamp { get; set; } = DateTime.Now;
        public override string ToString()
        {
            return $"{BitConverter.ToString(Hash).Replace("-", "")}: \n {BitConverter.ToString(PrevHash).Replace("-", "")} : \n {Nonce} {TimeStamp}";
        }
    }
}
