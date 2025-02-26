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
            
            Container.Bind<PlayerInput>()
                .AsSingle();
        }
    }
}