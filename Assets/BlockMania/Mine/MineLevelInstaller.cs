using BlockMania.Mine.BlocksSystem;
using BlockMania.Mine.Hero;
using BlockMania.Mine.UI;
using UnityEngine;
using Zenject;

namespace BlockMania.Mine
{
    public class MineLevelInstaller : MonoInstaller
    {
        [SerializeField] private Camera mainCamera;
        [SerializeField] private HeroSystem heroSystem;
        [SerializeField] private UISystem uiSystem;
        [SerializeField] private BlockSystem blockSystem;

        public void Update()
        {
            uiSystem.UpdatePass();
            blockSystem.UpdatePass();
        }
        
        public override void InstallBindings()
        {
            Application.targetFrameRate = 60;
            BindCamera();
            BindUISystem();
            BindHeroSystem();
            BindBlockSystem();
        }
        private void BindCamera()
        {
            Container.Bind<Camera>().FromInstance(mainCamera).AsSingle();
        }
        private void BindBlockSystem()
        {
            Container.Bind<BlockSystem>().FromInstance(blockSystem).AsSingle();
        }
        private void BindHeroSystem()
        {
            Container.Bind<HeroSystem>().FromInstance(heroSystem).AsSingle();
        }
        private void BindUISystem()
        {
            Container.Bind<UISystem>().FromInstance(uiSystem).AsSingle();
        }
    }
}