using System;
using UnityEngine;

namespace Space_Ship.Components
{
    public class HealthComponent
    {
        public event Action<int> OnHealthChanged;
        public event Action OnHealthEmpty;

        public int MaxHealth { get; }
        public int CurrentHealth { get; private set; }
        public bool IsDead => CurrentHealth <= 0;

        public HealthComponent(int maxHealth)
        {
            MaxHealth = CurrentHealth = maxHealth;
        }

        public void TakeDamage(int damage)
        {
            if (damage < 0)
            {
                return;
            }

            CurrentHealth = Mathf.Clamp(CurrentHealth - damage, 0, MaxHealth);
            OnHealthChanged?.Invoke(CurrentHealth);

            if (IsDead)
            {
                OnHealthEmpty?.Invoke();
            }
        }
    }
}