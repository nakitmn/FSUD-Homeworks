using SnakeGame;
using Zenject;

namespace UI_Module
{
    public sealed class UiInstaller : Installer<UiInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IGameUI>()
                .FromComponentInHierarchy()
                .AsSingle();
        
            Container.BindInterfacesTo<GameUiPresenter>()
                .AsSingle();
        }
    }
}