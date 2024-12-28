using UnityEngine;
using Zenject;

namespace Game.Presenters
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

            Container.Bind<PlanetPopupPresenter>()
                .AsSingle();
            
            Container.Bind<PlanetPopupShower>()
                .AsSingle();
        }
    }
}