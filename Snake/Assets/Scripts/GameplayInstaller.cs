using Coins_Module;
using DefaultNamespace;
using Input_Module;
using Level_Module;
using Snake_Module;
using UI_Module;
using UnityEngine;
using Zenject;

public sealed class GameplayInstaller : MonoInstaller
{
    [SerializeField] private GameConfig _gameConfig;
    [SerializeField] private Transform _coinsContainer;

    public override void InstallBindings()
    {
        Container.Bind<GameConfig>()
            .FromInstance(_gameConfig)
            .AsSingle();
        
        LevelInstaller.Install(Container, _gameConfig.LevelsCount);
        CoinsInstaller.Install(Container, _gameConfig.CoinPrefab, _coinsContainer);
        SnakeInstaller.Install(Container);
        InputInstaller.Install(Container);
        UiInstaller.Install(Container);
    }
}