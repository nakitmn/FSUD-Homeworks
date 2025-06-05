using UnityEngine;
using Zenject;

namespace Game
{
    public sealed class GameplayInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ProjectileViewPool>()
                .FromComponentInHierarchy()
                .AsSingle();
            
            Container.Bind<MoneyStorage>()
                .FromComponentInHierarchy()
                .AsSingle();
            
            Container.Bind<GameCycle>()
                .FromComponentInHierarchy()
                .AsSingle();
            
            Container.Bind<Portal>()
                .FromComponentInHierarchy()
                .AsSingle();
        }
    }
}