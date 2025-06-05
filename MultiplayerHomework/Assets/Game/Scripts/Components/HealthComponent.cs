using System;
using Codice.Client.BaseCommands.WkStatus.Printers;
using Fusion;
using UnityEngine;

namespace Game
{
    public sealed class HealthComponent : NetworkBehaviour
    {
        //View
        public event Action<int> OnHealthChanged;

        [Networked]
        [UnityNonSerialized]
        [OnChangedRender(nameof(InvokeHealthChanged))]
        public int Health { get; private set; }

        [Networked] 
        public int MaxHealth { get; private set; }

        public float NormalizedHealth => Health / (float) MaxHealth;

        public override void Spawned()
        {
            Health = MaxHealth;
            InvokeHealthChanged();
        }

        public bool TakeDamage(int damage)
        {
            if (Health == 0)
                return false;

            Health = Mathf.Max(0, Health - damage);
            return true;
        }

        public bool Exists()
        {
            return Health > 0;
        }

        private void InvokeHealthChanged()
        {
            OnHealthChanged?.Invoke(Health);
        }
    }
}