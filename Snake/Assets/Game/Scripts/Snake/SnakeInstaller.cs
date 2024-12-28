using Level_Module;
using Modules;
using Zenject;

namespace Snake_Module
{
    public sealed class SnakeInstaller : Installer<SnakeInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<ISnake>()
                .FromComponentInHierarchy()
                .AsSingle();

            Container.BindInterfacesTo<SnakeMoveController>()
                .AsSingle();

            Container.BindInterfacesTo<SnakeExpandController>()
                .AsSingle();

            Container.BindInterfacesTo<SnakeDisableController>()
                .AsSingle();

            Container.BindInterfacesTo<SnakeSpeedUpController>()
                .AsSingle();
        }
    }
}