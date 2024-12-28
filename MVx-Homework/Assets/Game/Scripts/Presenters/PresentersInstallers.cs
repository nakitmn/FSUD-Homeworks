using Game.Views;
using Modules.Planets;
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
            Container.BindInterfacesTo<PlanetCollectionPresenter>()
                .AsSingle();

            Container.BindInterfacesAndSelfTo<MoneyPresenter>()
                .AsSingle();

            Container.Bind<PlanetPopupPresenter>()
                .AsSingle();
            
            Container.Bind<PlanetPopupShower>()
                .AsSingle();

            Container.BindFactory<Planet, PlanetView, PlanetPresenter, PlanetPresenterFactory>()
                .AsSingle();

            Container.Bind<IPlanetPresenterFactory>()
                .To<PlanetPresenterFactory>()
                .FromResolve();
        }
    }
}