using Zenject;

namespace BlockMania.Bootstrap
{
    public class MineInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            var mineLevelManager = new MineLevelManager();
            Container.Bind<MineLevelManager>().FromInstance(mineLevelManager).AsSingle();
        }
    }
}