using DG.Tweening;
using Modules.Money;
using Modules.UI;
using UnityEngine;
using Zenject;

namespace Game.Scripts.UI
{
    public sealed class MoneyFacade : IInitializable
    {
        private readonly IMoneyStorage _moneyStorage;
        private readonly MoneyView _moneyView;
        private readonly ParticleAnimator _particleAnimator;

        private int _visualAmount;
        private Tweener _counterAnimation;

        public MoneyFacade(IMoneyStorage moneyStorage, MoneyView moneyView, ParticleAnimator particleAnimator)
        {
            _moneyStorage = moneyStorage;
            _moneyView = moneyView;
            _particleAnimator = particleAnimator;
        }

        void IInitializable.Initialize()
        {
            Sync();
        }

        public void Print()
        {
            _moneyView.SetAmount(_visualAmount.ToString());
        }

        public void Sync()
        {
            _visualAmount = _moneyStorage.Money;
            Print();
        }

        public void PlayCoin(RectTransform from, int addAmount)
        {
            _particleAnimator.Emit(
                from.position,
                _moneyView.IconPivot.position,
                onFinished: () => AddWithCounter(addAmount)
            );
        }

        public void SyncWithCounter()
        {
            PlayCounter(_moneyStorage.Money);
        }

        public void AddWithCounter(int amount)
        {
            PlayCounter(_visualAmount + amount);
        }

        private void PlayCounter(int to)
        {
            if (_counterAnimation.IsActive())
            {
                _counterAnimation.Complete();
            }

            _counterAnimation = DOVirtual.Int(
                _visualAmount,
                to,
                0.3f,
                newAmount =>
                {
                    _visualAmount = newAmount;
                    Print();
                }
            );
        }
    }
}