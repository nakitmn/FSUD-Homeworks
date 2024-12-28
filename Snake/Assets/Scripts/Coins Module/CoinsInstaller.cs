using Level_Module;
using Modules;
using UnityEngine;
using Zenject;

namespace Coins_Module
{
    public sealed class CoinsInstaller : Installer<GameObject, Transform, CoinsInstaller>
    {
        [Inject] private GameObject _coinPrefab;
        [Inject] private Transform _coinsContainer;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<CoinsManager>()
                .AsSingle();

            Container.BindInterfacesTo<CoinCollectController>()
                .AsSingle();

            Container.BindInterfacesTo<CoinsSpawnController>()
                .AsSingle();

            Container.BindMemoryPoolCustomInterface<Coin, CoinsPool, ICoinsPool>()
                .FromComponentInNewPrefab(_coinPrefab)
                .UnderTransform(_coinsContainer)
                .AsSingle();
        }
    }
}