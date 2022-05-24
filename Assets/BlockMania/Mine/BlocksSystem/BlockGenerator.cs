using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BlockMania.Mine.BlocksSystem
{
    public class BlockGenerator : MonoBehaviour
    {
        private readonly List<Vector3> _occupiedPositions = new()
        {
            new Vector3(0,1,0),
            new Vector3(0,2,0),
            new Vector3(0,2,1),
            new Vector3(0,1,1)
        };

        private const int WidthByX = 3;
        private const int WidthByZ = 3;
        private const int Height = 3;
        private BlockRandomizer blockRandomizer;
        
        public void Initialize(MineLevels.MineLevels mineLevels, int mineLevel)
        {
            blockRandomizer = new BlockRandomizer(mineLevels.GetMineLevel(mineLevel).blocks);
            BuildBoxEnvironment(Vector3.zero);
        }

        private void BuildBoxEnvironment(Vector3 startPos)
        {
            var currentPos = startPos;
            var currentX = Convert.ToInt32(currentPos.x);
            var currentZ = Convert.ToInt32(currentPos.z);
            for (var x = currentX - WidthByX; x <= currentX + WidthByX; x++)
            {
                for (var z = currentZ - WidthByZ; z <= currentZ + WidthByZ; z++)
                {
                    for (var y = 0; y <= Height; y++)
                    {
                        currentPos = new Vector3(x,y,z);
                        if (IsPointOccupied(currentPos)) SpawnBlock(currentPos);   
                    }
                }
            }
        }

        private void SpawnBlock(Vector3 pos)
        {
            var blockPrefab = blockRandomizer.GerRandomBlock();
            var block = Instantiate(blockPrefab, pos, Quaternion.identity, ((Component)this).transform);
            block.Initialize();
            block.OnDestroyBlockEvent += BuildBoxEnvironment;
            _occupiedPositions.Add(block.transform.position);
            ChangeDigabilityBlock(block);
        }

        private static void ChangeDigabilityBlock(Blocks.Block block)
        {
            var currentPos = Vector3Int.RoundToInt(block.transform.position);
            block.isDigable = currentPos.y is not (3 or 0);
        }

        private bool IsPointOccupied(Vector3 pos)
        {
            return _occupiedPositions.All(occupiedPosition => occupiedPosition != pos);
        }
    }
}
