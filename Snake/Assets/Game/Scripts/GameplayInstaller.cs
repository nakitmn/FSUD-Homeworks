using Game.UI;
using UnityEngine;
using Zenject;

namespace Game.Gameplay
{
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
}