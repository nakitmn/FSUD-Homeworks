using Fusion;
using UnityEngine;
using Zenject;

namespace Game
{
    public sealed class Player : NetworkBehaviour
    {
        [SerializeField] private MoveComponent _moveComponent;
        [SerializeField] private RotationComponent _rotationComponent;
        [SerializeField] private ShootComponent _shootComponent;
        [SerializeField] private HealthComponent _healthComponent;
        [SerializeField] private InputReceiver _inputReceiver;

        private GameCycle _gameCycle;

        [Inject]
        public void Construct(GameCycle gameCycle)
        {
            _gameCycle = gameCycle;
        }

        public override void Spawned()
        {
            _moveComponent.SetCondition(() => _healthComponent.Exists()
                                              && _gameCycle.CurrentState == GameCycle.State.Running);
            _rotationComponent.SetCondition(() => _healthComponent.Exists()
                                                  && _gameCycle.CurrentState == GameCycle.State.Running);
            _shootComponent.SetCondition(() => _healthComponent.Exists()
                                               && _gameCycle.CurrentState == GameCycle.State.Running
                                               && _inputReceiver.InputData.moveDirection == Vector3.zero);
        }

        public void TakeDamage(int damage)
        {
            _healthComponent.TakeDamage(damage);
        }
    }
}