using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twkelat.Core.Interfaces;

namespace Twkelat.Core.Models
{
    public class Block : IBlock
    {
        public Block(byte[] data)
        {
            Data = data;
            Nonce = 0;
            PrevHash = [0x00];
            TimeStamp = DateTime.Now;
        }
        public byte[] Data { get; }
        public byte[] Hash { get; set; }
        public byte[] PrevHash { get; set; }
        public int Nonce { get; set; }
        public DateTime TimeStamp { get; set; }
        public override string ToString()
        {
            return $"{BitConverter.ToString(Hash).Replace("-", "")}: \n {BitConverter.ToString(PrevHash).Replace("-", "")} : \n {Nonce} {TimeStamp}";
        }
    }
}
