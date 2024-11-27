using Input_Module;
using Modules;
using SnakeGame;
using UnityEngine;
using Zenject;

namespace DefaultNamespace
{
    public sealed class SceneInstaller : MonoInstaller
    {
        [SerializeField] private GameObject _coinPrefab;
        [SerializeField] private Transform _coinsContainer;
        [SerializeField] private int _levelsCount = 9;

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
            
            Container.BindInterfacesAndSelfTo<CoinsManager>()
                .AsSingle()
                .NonLazy();
            
            Container.BindInterfacesAndSelfTo<LevelManager>()
                .AsSingle()
                .NonLazy();

            Container.BindInterfacesTo<Difficulty>()
                .AsSingle()
                .WithArguments(_levelsCount);

            Container.BindMemoryPoolCustomInterface<Coin,CoinsPool,ICoinsPool>()
                .FromComponentInNewPrefab(_coinPrefab)
                .UnderTransform(_coinsContainer)
                .AsSingle();
        }
    }
}