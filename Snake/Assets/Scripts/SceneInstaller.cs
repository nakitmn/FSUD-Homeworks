using Input_Module;
using Modules;
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
            
            Container.BindInterfacesTo<PlayerInput>()
                .AsSingle();
            
            Container.BindInterfacesTo<SnakeMoveController>()
                .AsSingle()
                .NonLazy();
        }
    }
}