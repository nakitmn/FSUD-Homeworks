using Game.Scripts.UI;
using Modules.Money;
using Zenject;

namespace Game.Gameplay
{
    public sealed class MoneyInstaller : Installer<int, MoneyInstaller>
    {
        [Inject]
        private int _initialMoney;
        
        public override void InstallBindings()
        {
            this.Container
                .BindInterfacesAndSelfTo<MoneyStorage>()
                .AsSingle()
                .WithArguments(_initialMoney)
                .NonLazy();

            this.Container
                .BindInterfacesTo<MoneyAdapter>()
                .AsSingle()
                .NonLazy();

            Container.Bind<MoneyView>()
                .FromComponentInHierarchy()
                .AsSingle();
            
            Container.BindInterfacesAndSelfTo<MoneyFacade>()
                .AsSingle();
        }
    }
}