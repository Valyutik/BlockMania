using System.Collections.Generic;
using BlockMania.Mine.BlocksSystem.Blocks;
using Random = UnityEngine.Random;

namespace BlockMania.Mine.BlocksSystem
{
    public class BlockRandomizer
    {
        private readonly Block[] _blocks;

        public BlockRandomizer(Block[] blocks)
        {
            _blocks = blocks;
        }

        public Block GerRandomBlock()
        {
            return _blocks[Random.Range(0, _blocks.Length)];
        }
    }
}