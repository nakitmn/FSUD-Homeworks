using Game.Scripts.Views.Money;
using Game.Scripts.Views.Planet;
using Modules.UI;
using Zenject;

namespace Game.Scripts.Views
{
    public sealed class ViewsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<PlanetView>()
                .FromComponentsInHierarchy()
                .AsCached();
            
            Container.Bind<PlanetInfoPopup>()
                .FromComponentsInHierarchy()
                .AsSingle();
            
            Container.Bind<ParticleAnimator>()
                .FromComponentsInHierarchy()
                .AsSingle();
            
            Container.Bind<MoneyView>()
                .FromComponentInHierarchy()
                .AsSingle();
        }
    }
}