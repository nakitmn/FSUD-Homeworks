using System;

namespace Modules.Health
{
    public class Health
    {
        public event Action OnDied;
        public event Action<int> OnDamaged;
        public event Action<int> OnHealed;
        public event Action<int> OnMaxHealthChanged;

        public int MaxHealth { get; private set; }
        public int CurrentHealth { get; private set; }
        public bool IsAlive => CurrentHealth > 0;

        public Health()
        {
            MaxHealth = CurrentHealth = 1;
        }

        public Health(int maxHealth)
        {
            if (maxHealth <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(maxHealth));
            }

            MaxHealth = CurrentHealth = maxHealth;
        }

        public Health(int maxHealth, int currentHealth) : this(maxHealth)
        {
            if (currentHealth < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(currentHealth));
            }

            CurrentHealth = currentHealth;
        }

        public void Damage(int damage)
        {
            if (damage < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(damage));
            }

            var delta = CurrentHealth - damage;
            if (delta < 0)
            {
                damage += delta;
            }

            if (damage == 0)
            {
                return;
            }

            CurrentHealth -= damage;
            OnDamaged?.Invoke(damage);
            
            if (IsAlive == false)
            {
                OnDied?.Invoke();
            }
        }

        public void InstantDie()
        {
            if (IsAlive == false)
            {
                return;
            }
            
            CurrentHealth = 0;
            OnDied?.Invoke();
        }

        public void HealAll()
        {
            Heal(MaxHealth);
        }

        public void Heal(int healValue)
        {
            if (healValue < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(healValue));
            }

            if (CurrentHealth >= MaxHealth)
            {
                return;
            }

            var delta = MaxHealth - (CurrentHealth + healValue);
            if (delta < 0)
            {
                healValue += delta;
            }

            if (healValue == 0)
            {
                return;
            }

            CurrentHealth += healValue;
            OnHealed?.Invoke(healValue);
        }

        public void ChangeMaxHealth(int newMaxHealth, bool withCurrentHealth = false)
        {
            if (newMaxHealth <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(newMaxHealth));
            }
            
            if (MaxHealth == newMaxHealth)
            {
                return;
            }

            MaxHealth = newMaxHealth;

            if (withCurrentHealth)
            {
                CurrentHealth = newMaxHealth;
            }

            OnMaxHealthChanged?.Invoke(newMaxHealth);
        }
    }
}