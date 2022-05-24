using UnityEngine;

namespace BlockMania.Mine.BlocksSystem.MineLevels
{
    public class MineLevels : MonoBehaviour
    {
        [SerializeField] private MineLevel[] levels;
        
        public void Initialize()
        {
            
        }

        public MineLevel GetMineLevel(int mineLevel)
        {
            return levels[mineLevel];
        }
    }
}