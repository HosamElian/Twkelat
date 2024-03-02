using System.Collections;
using Twkelat.Persistence.BlockExtension;

namespace Twkelat.Persistence.Models
{
    public class BlockChain : IEnumerable<IBlock>
    {
        private List<IBlock> _items = new List<IBlock>();
        public List<IBlock> Items
        {
            get => _items; 
            set => _items = value;

        }
        public byte[] Difficulty { get; }
        public int Count => _items.Count;
        public BlockChain(byte[] difficulty, IBlock genesis)
        {
            Difficulty = difficulty;
            genesis.Hash = genesis.MineHash(difficulty);
            Items.Add(genesis);
        }

        public void Add(IBlock block)
        {
            if (_items?.LastOrDefault() is not null)
            {
                block.PrevHash = _items.LastOrDefault().Hash;
            }
            block.Hash = block.MineHash(Difficulty);
            Items.Add(block);

        }
        public IBlock this[int index]
        {
            get => Items[index];
            set => Items[index] = value;    
        }
        public IEnumerator<IBlock> GetEnumerator()
        {
            return Items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Items.GetEnumerator();
        }
    }
}
