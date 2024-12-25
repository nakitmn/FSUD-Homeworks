using Game.Scripts.Presenters.Money;
using Game.Scripts.Presenters.Planet;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Presenters
{
    [CreateAssetMenu(
        fileName = "PresentersInstallers",
        menuName = "Zenject/New PresentersInstallers"
    )]
    public sealed class PresentersInstallers : ScriptableObjectInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<PlanetPresentersLinker>()
                .AsSingle();

            Container.BindInterfacesAndSelfTo<MoneyFacade>()
                .AsSingle();
        }
    }
}