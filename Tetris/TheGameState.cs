using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class TheGameState
    {
        private Block currentBlock;

        public Block CurrentBlock
        {
            get => currentBlock;
            private set
            {
                currentBlock = value;
                currentBlock.Reset();
            }
        }

        public Grid Grid { get; }
        public BlockQueues blockQueues { get; }
        public bool GameOver { get; private set; }

        public TheGameState()
        {
            Grid = new Grid(22, 10);
            blockQueues = new BlockQueues();
            CurrentBlock = blockQueues.GetNextBlock();
        }

        private bool BlockFits()
        {
            foreach (Positions p in CurrentBlock.TilePositions())
            {
                if (!Grid.IsEmpty(p.Row, p.Column))
                {
                    return false;
                }
            }
            return true;
        }

        public void rotateBlockCW()
        {
            CurrentBlock.RotateCW();
            if (!BlockFits())
            {
                CurrentBlock.RotateCCW();
            }
        }

        public void rotateBlockCCW()
        {
            CurrentBlock.RotateCCW();
            if (!BlockFits())
            {
                CurrentBlock.RotateCW();
            }
        }

        public void moveBlockLeft()
        {
            CurrentBlock.Move(0, -1);
            if (!BlockFits())
            {
                CurrentBlock.Move(0, 1);
            }
        }
        
        public void moveBlockRight()
        {
            CurrentBlock.Move(0, 1);
            if (!BlockFits())
            {
                CurrentBlock.Move(0, -1);
            }
        }
       
        private bool isGameOver()
        {
           return !(Grid.IsRowEmpty(0) && Grid.IsRowEmpty(1));
        }

        private void placeBlock()
        {
            foreach (Positions p in CurrentBlock.TilePositions())
            {
               Grid[p.Row, p.Column] = CurrentBlock.Id;
            }

            Grid.ClearFullRows();

            if (isGameOver())
            {
                GameOver = true;
            }
            else
            {
                CurrentBlock = blockQueues.GetNextBlock();
            }
        }

        public void moveBlockDown()
        {
            CurrentBlock.Move(1, 0);

            if (!BlockFits())
            {
                CurrentBlock.Move(-1, 0);
                placeBlock();
            }
        }

    }
}
