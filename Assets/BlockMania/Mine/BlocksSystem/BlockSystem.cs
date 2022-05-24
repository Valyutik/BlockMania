using BlockMania.Mine.UI;
using UnityEngine;
using Zenject;

namespace BlockMania.Mine.BlocksSystem
{
    public class BlockSystem : MonoBehaviour
    {
        public int mineLevel;
        [SerializeField] private BlockDigger blockDigger;
        [SerializeField] private BlockGenerator blockGenerator;
        [SerializeField] private MineLevels.MineLevels mineLevels;
        public IDigger Digger => blockDigger;

        [Inject]
        public void Initialize(UISystem uiSystem, Camera mainCamera)
        {
            mineLevel = PlayerPrefs.GetInt("grgreg") switch
            {
                1 => 0,
                0 => 1,
                _ => mineLevel
            };
            PlayerPrefs.SetInt("grgreg", mineLevel);
            mineLevels.Initialize();
            blockGenerator.Initialize(mineLevels, mineLevel);
            blockDigger.Initialize(mainCamera);
            uiSystem.DigButton.OnEndHoldEvent += blockDigger.OnStopDigPreviousBlock;
        }

        public void UpdatePass()
        {
            blockDigger.UpdatePass();
        }
    }
}