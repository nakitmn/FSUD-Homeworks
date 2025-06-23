using System;
using Fusion;

namespace Game
{
    public sealed class MoneyStorage : NetworkBehaviour
    {
        public event Action OnMoneyChanged;

        [Networked, OnChangedRender(nameof(InvokeMoneyChanged))]
        public int Money { get; private set; }

        public override void Spawned()
        {
            OnMoneyChanged?.Invoke();
        }

        public bool Exists(int amount)
        {
            return amount <= Money;
        }

        public bool Spend(int amount)
        {
            if (Exists(amount) == false)
            {
                return false;
            }

            Money -= amount;
            return true;
        }

        public void Earn(int amount)
        {
            Money += amount;
        }

        private void InvokeMoneyChanged()
        {
            OnMoneyChanged?.Invoke();
        }
    }
}