using Game.Scripts.UI.Money;
using Game.Scripts.UI.Planets;
using Modules.UI;
using Zenject;

namespace Game.Scripts.UI
{
    public sealed class UiInstaller : Installer<UiInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<PlanetView>()
                .FromComponentsInHierarchy()
                .AsCached();

            Container.BindInterfacesTo<PlanetPresentersLinker>()
                .AsSingle();
            
            Container.Bind<PlanetInfoPopup>()
                .FromComponentsInHierarchy()
                .AsSingle();
            
            Container.Bind<ParticleAnimator>()
                .FromComponentsInHierarchy()
                .AsSingle();
            
            Container.Bind<MoneyView>()
                .FromComponentInHierarchy()
                .AsSingle();
            
            Container.BindInterfacesAndSelfTo<MoneyFacade>()
                .AsSingle();
        }
    }
}