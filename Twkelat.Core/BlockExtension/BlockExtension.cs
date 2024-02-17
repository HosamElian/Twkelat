using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Twkelat.Core.Interfaces;

namespace Twkelat.Core.BlockExtension
{
    public static class BlockExtension
    {
        public static byte[] GenerateHash(this IBlock block)
        {
            using SHA512 sha = new SHA512Managed();
            using MemoryStream ms = new MemoryStream();
            using BinaryWriter bw = new BinaryWriter(ms);
            bw.Write(block.Data);
            bw.Write(block.Nonce);
            bw.Write(block.PrevHash);
            bw.Write(block.TimeStamp.ToString());
            var s = ms.ToArray();
            return sha.ComputeHash(s);
        }
        public static byte[] MineHash(this IBlock block, byte[] difficulty)
        {
            if (difficulty == null) throw new ArgumentNullException(nameof(difficulty));

            byte[] hash = new byte[0];
            while(!hash.Take(2).SequenceEqual(difficulty))
            {
                block.Nonce++;
                hash = block.GenerateHash();

            }
            return hash;
        }
        public static bool IsValid(this IBlock block)
        {
            var bk = block.GenerateHash();
            return block.Hash.SequenceEqual(bk);
        }
        public static bool IsPrevBlock(this IBlock block, IBlock prevBlock)
        {
            if(prevBlock == null) throw new ArgumentNullException(nameof(prevBlock));
            return prevBlock.IsValid() && block.PrevHash.SequenceEqual(prevBlock.Hash);
        }

        public static bool IsValid(this IEnumerable<IBlock> items)
        {
            var enums = items.ToList();
            return enums.Zip(enums.Skip(1), Tuple.Create).All(block => block.Item2.IsValid()
                && block.Item2.IsPrevBlock(block.Item1));
        }
    }
}
