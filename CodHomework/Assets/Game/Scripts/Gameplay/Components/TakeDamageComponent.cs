using Modules.Health;

namespace Game.Gameplay
{
    public sealed class TakeDamageComponent
    {
        private readonly Health _health;

        public TakeDamageComponent(Health health)
        {
            _health = health;
        }

        public void Damage(int damage)
        {
            _health.Damage(damage); 
        }
    }
}