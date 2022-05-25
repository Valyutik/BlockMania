using BlockMania.Bootstrap;
using BlockMania.Mine.BlocksSystem.MineLevels;
using BlockMania.Mine.UI;
using UnityEngine;
using Zenject;

namespace BlockMania.Mine.BlocksSystem
{
    public class BlockSystem : MonoBehaviour
    {
        [SerializeField] private BlockDigger blockDigger;
        [SerializeField] private BlockGenerator blockGenerator;
        [SerializeField] private MineLevel[] mineLevels;
        public IDigger Digger => blockDigger;

        private int currentMineLevel;
        private MineLevelManager _mineLevelManager;
        
        [Inject]
        public void Initialize(UISystem uiSystem, Camera mainCamera, MineLevelManager mineLevelManager)
        {
            _mineLevelManager = mineLevelManager;
            currentMineLevel = _mineLevelManager.CurrentMineLevel;
            blockGenerator.Initialize(mineLevels[currentMineLevel]);
            blockDigger.Initialize(mainCamera);
            uiSystem.DigButton.OnReleaseEvent += blockDigger.OnStopDigPreviousBlock;
            uiSystem.SceneСhangeTestButtonUp.OnPressEvent += MineLevelUp;
            uiSystem.SceneСhangeTestButtonDown.OnPressEvent += MineLevelDown;
        }

        public void UpdatePass()
        {
            blockDigger.UpdatePass();
        }

        private void MineLevelUp()
        {
            if (_mineLevelManager.CurrentMineLevel + 1 < mineLevels.Length)
            {
                _mineLevelManager.MineLevelUp();
            }
        }

        private void MineLevelDown()
        {
            Debug.Log(1);
            if (_mineLevelManager.CurrentMineLevel - 1 >= 0)
            {
                Debug.Log(2);
                _mineLevelManager.MineLevelDown();
            }
        }
    }
}