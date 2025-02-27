using UnityEngine;
using Zenject;

namespace Game.Gameplay
{
    [CreateAssetMenu(menuName = "Game/Installers/Player Installer", order = 0)]
    public sealed class PlayerInstaller : ScriptableObjectInstaller
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