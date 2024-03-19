using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class SshapedBlock : Block
    {
        private readonly Positions[][] tiles = new Positions[][]
        {
            new Positions[] { new(0, 1), new(0, 2), new(1, 0), new(1, 1) },
            new Positions[] { new(0, 0), new(1, 0), new(1, 1), new(2, 1) }
        };

        public override int Id => 5;
        protected override Positions StartOffset => new Positions(-1, 3);
        protected override Positions[][] Tiles => tiles;
    }
}
