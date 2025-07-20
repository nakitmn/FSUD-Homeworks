using SampleGame;
using UnityEngine;

namespace SampleGame
{
    public struct DealDamageCommand : ICommand
    {
        private readonly IGameEntity _source;
        private readonly IGameEntity _target;

        public DealDamageCommand(IGameEntity source, IGameEntity target)
        {
            _source = source;
            _target = target;
        }

        public bool Execute(IGameContext gameContext)
        {
            return DealDamage();
        }

        private bool DealDamage()
        {
            if (_target.GetHealth() == 0)
            {
                return false;
            }

            var damage = _source.GetDamage();
            var health = _target.GetHealth();
            _target.SetHealth(Mathf.Max(0, health - damage));
            return true;
        }
    }
}