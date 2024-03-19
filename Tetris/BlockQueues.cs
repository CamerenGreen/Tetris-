using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class BlockQueues
    {
        private readonly Block[] blocks = new Block[]
        {
            new IshapedBlock(),
            new OshapedBlock(),
            new JshapedBlock(),
            new SshapedBlock(),
            new ZshapedBlock(),
            new TshapedBlock(),
            new LshapedBlock()
        };

        private readonly Random random = new Random();
        public Block NextBlock { get; private set; }
        public BlockQueues()
        {
            NextBlock = RandomBlock();
        }
        private Block RandomBlock()
        {
            return blocks[random.Next(blocks.Length)];
        }

        public Block GetNextBlock()
        {
            Block block = NextBlock;

            do
            {
                NextBlock = RandomBlock();
            }
            while (NextBlock.Id == block.Id);

            return block;
        }
    }

}
