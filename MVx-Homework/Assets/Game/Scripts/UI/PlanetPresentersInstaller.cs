using Zenject;

namespace Game.Scripts.UI
{
    public sealed class PlanetPresentersInstaller : Installer<PlanetPresentersInstaller>
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
        }
    }
}