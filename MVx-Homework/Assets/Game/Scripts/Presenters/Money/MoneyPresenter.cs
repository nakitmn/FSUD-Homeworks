using Game.Views;
using Modules.Money;
using Modules.UI;
using UnityEngine;
using Zenject;

namespace Game.Presenters
{
    public sealed class MoneyPresenter : IInitializable
    {
        private readonly IMoneyStorage _moneyStorage;
        private readonly MoneyView _moneyView;
        private readonly ParticleAnimator _particleAnimator;

        private int _visualAmount;

        public MoneyPresenter(IMoneyStorage moneyStorage, MoneyView moneyView, ParticleAnimator particleAnimator)
        {
            _moneyStorage = moneyStorage;
            _moneyView = moneyView;
            _particleAnimator = particleAnimator;
        }

        void IInitializable.Initialize()
        {
            Sync();
        }

        public void Sync()
        {
            _visualAmount = _moneyStorage.Money;
            Print();
        }
        
        public void SyncWithCounter()
        {
            _moneyView.PlayCounter(_visualAmount, _moneyStorage.Money);
            _visualAmount = _moneyStorage.Money;
        }

        public void AddWithCounter(int amount)
        {
            var newAmount = _visualAmount + amount;
            _moneyView.PlayCounter(_visualAmount, newAmount);
            _visualAmount = newAmount;
        }

        public void PlayCoin(RectTransform from, int addAmount)
        {
            _particleAnimator.Emit(
                from.position,
                _moneyView.IconPivot.position,
                onFinished: () => AddWithCounter(addAmount)
            );
        }

        private void Print()
        {
            _moneyView.SetAmount(_visualAmount.ToString());
        }
    }
}