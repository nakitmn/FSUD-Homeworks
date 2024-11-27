using Coins_Module;
using DefaultNamespace;
using Input_Module;
using Level_Module;
using Modules;
using Snake_Module;
using SnakeGame;
using UI_Module;
using UnityEngine;
using Zenject;

public sealed class GameplayInstaller : MonoInstaller
{
    [SerializeField] private GameConfig _gameConfig;
    [SerializeField] private Transform _coinsContainer;

    public override void InstallBindings()
    {
        BindNativeModules();
        BindCustomDependencies();
    }

    private void BindCustomDependencies()
    {
        Container.Bind<GameConfig>()
            .FromInstance(_gameConfig)
            .AsSingle();
        
        Container.BindInterfacesTo<PlayerInput>()
            .AsSingle();

        Container.BindInterfacesTo<SnakeMoveController>()
            .AsSingle();

        Container.BindInterfacesAndSelfTo<CoinsManager>()
            .AsSingle();

        Container.BindInterfacesAndSelfTo<LevelManager>()
            .AsSingle();
        
        Container.BindInterfacesTo<GameUiPresenter>()
            .AsSingle();

        Container.BindMemoryPoolCustomInterface<Coin, CoinsPool, ICoinsPool>()
            .FromComponentInNewPrefab(_gameConfig.CoinPrefab)
            .UnderTransform(_coinsContainer)
            .AsSingle();
    }

    private void BindNativeModules()
    {
        Container.BindInterfacesTo<Difficulty>()
            .AsSingle()
            .WithArguments(_gameConfig.LevelsCount);
        
        Container.BindInterfacesTo<Score>()
            .AsSingle();
        
        Container.Bind<ISnake>()
            .FromComponentInHierarchy()
            .AsSingle();

        Container.Bind<IGameUI>()
            .FromComponentInHierarchy()
            .AsSingle();

        Container.Bind<IWorldBounds>()
            .FromComponentInHierarchy()
            .AsSingle();
    }
}