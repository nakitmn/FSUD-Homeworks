using UnityEngine;

namespace SampleGame
{
    public struct DealDamageCommand : ICommand
    {
        private readonly IGameEntity _target;
        private readonly int _damage;

        public DealDamageCommand(IGameEntity target, int damage)
        {
            _target = target;
            _damage = damage;
        }

        public bool Execute(IGameContext gameContext)
        {
            if (DealDamage())
            {
                gameContext.GetEventBus().InvokeDamaged(_target, _damage);
                //gameContext.GetAnimationQueue().Enqueue(new DealDamageAnimationCommand(_target.GetTransform()));
                return true;
            }

            return false;
        }

        private bool DealDamage()
        {
            if (HealthUseCase.Exists(_target) == false)
            {
                return false;
            }

            var health = _target.GetHealth();
            _target.SetHealth(Mathf.Max(0, health - _damage));
            return true;
        }
    }
}