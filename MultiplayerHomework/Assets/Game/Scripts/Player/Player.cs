using Fusion;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Game
{
    public sealed class Player : NetworkBehaviour
    {
        [SerializeField] private MoveComponent _moveComponent;
        [SerializeField] private RotationComponent _rotationComponent;
        [SerializeField] private ShootBehaviour _shootBehaviour;
        [SerializeField] private HealthComponent _healthComponent;
        [SerializeField] private DeathComponent _deathComponent;
        [SerializeField] private InputReceiver _inputReceiver;

        private GameCycle _gameCycle;

        [Inject]
        public void Construct(GameCycle gameCycle)
        {
            _gameCycle = gameCycle;
        }

        public override void Spawned()
        {
            _moveComponent.SetCondition(() => _deathComponent.IsDead == false
                                              && _gameCycle.CurrentState == GameCycle.State.Running);
            _rotationComponent.SetCondition(() => _deathComponent.IsDead == false
                                                  && _gameCycle.CurrentState == GameCycle.State.Running);
            _shootBehaviour.SetCondition(() => _deathComponent.IsDead == false
                                               && _gameCycle.CurrentState == GameCycle.State.Running
                                               && _inputReceiver.InputData.moveDirection == Vector3.zero);
        }

        public override void FixedUpdateNetwork()
        {
            _deathComponent.IsDead = _healthComponent.Exists() == false;
        }

        public void TakeDamage(int damage)
        {
            _healthComponent.TakeDamage(damage);
        }
    }
}