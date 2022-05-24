using UnityEngine;

namespace BlockMania.Mine.BlocksSystem.MineLevels
{
    [CreateAssetMenu(fileName = "MineLevel", menuName = "Mine/MineLevel")]
    public class MineLevel : ScriptableObject
    {
        public Blocks.Block[] blocks;
    }
}