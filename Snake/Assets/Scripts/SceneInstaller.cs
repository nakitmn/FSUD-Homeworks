using Input_Module;
using Modules;
using SnakeGame;
using Zenject;

namespace DefaultNamespace
{
    public sealed class SceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ISnake>()
                .FromComponentInHierarchy()
                .AsSingle();
            
            Container.Bind<IGameUI>()
                .FromComponentInHierarchy()
                .AsSingle();
            
            Container.Bind<IWorldBounds>()
                .FromComponentInHierarchy()
                .AsSingle();
            
            Container.BindInterfacesTo<PlayerInput>()
                .AsSingle();
            
            Container.BindInterfacesTo<SnakeMoveController>()
                .AsSingle()
                .NonLazy();
            
            Container.BindInterfacesTo<GameOverController>()
                .AsSingle()
                .NonLazy();
        }
    }
}