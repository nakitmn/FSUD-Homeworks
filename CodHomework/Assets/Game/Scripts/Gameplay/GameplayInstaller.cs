using Zenject;

namespace Game.Gameplay
{
    public sealed class GameplayInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<Character>()
                .FromComponentInHierarchy()
                .AsSingle();

            Container.BindInterfacesTo<CharacterMoveController>()
                .AsSingle()
                .NonLazy();
            
            Container.BindInterfacesTo<CharacterJumpController>()
                .AsSingle()
                .NonLazy();
            
            Container.BindInterfacesTo<CharacterPushController>()
                .AsSingle()
                .NonLazy();
            
            Container.Bind<PlayerInput>()
                .AsSingle();
        }
    }
}