using Fusion;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Game
{
    public sealed class Enemy : NetworkBehaviour
    {
        [SerializeField] private HealthComponent _healthComponent;
        [SerializeField] private DeathComponent _deathComponent;
        [SerializeField] private MoveComponent _moveComponent;
        [SerializeField] private RotationComponent _rotationComponent;
        [SerializeField] private CollisionComponent _collisionComponent;
        [SerializeField] private EnemyConfig _config;

        [Networked] private TickTimer PlayerDamageTimer { get; set; }

        public bool IsDead => _deathComponent.IsDead;
        
        private GameObject _target;
        private MoneyStorage _moneyStorage;

        [Inject]
        public void Construct(MoneyStorage moneyStorage)
        {
            _moneyStorage = moneyStorage;
        }

        public void Init(GameObject target)
        {
            _target = target;
        }

        public override void Spawned()
        {
            _collisionComponent.OnCollided += OnCollided;
        }

        public override void Despawned(NetworkRunner runner, bool hasState)
        {
            _collisionComponent.OnCollided -= OnCollided;
        }

        public override void FixedUpdateNetwork()
        {
            if (_deathComponent.IsDead)
            {
                return;
            }

            if (_healthComponent.Exists() == false)
            {
                _deathComponent.IsDead = true;
                _moveComponent.IsMoving = false;
                CollectReward();
                return;
            }

            MoveToPortal();
        }

        public void TakeDamage(int damage)
        {
            _healthComponent.TakeDamage(damage);
        }

        private void CollectReward()
        {
            var rewardRange = _config.Reward;
            var reward = Random.Range(rewardRange.x, rewardRange.y);
            _moneyStorage.Earn(reward);
        }

        private void MoveToPortal()
        {
            var direction = _target.transform.position - transform.position;
            var directionNormalized = direction.normalized;

            _moveComponent.IsMoving = true;
            _moveComponent.MoveStep(directionNormalized, Runner.DeltaTime);
            _rotationComponent.RotateStep(directionNormalized, Runner.DeltaTime);
        }

        private void OnCollided(Collider[] colliders, int count)
        {
            if (_deathComponent.IsDead)
            {
                return;
            }

            for (var i = 0; i < count; i++)
            {
                var collider = colliders[i];

                if (PlayerDamageTimer.ExpiredOrNotRunning(Runner))
                {
                    var player = collider.GetComponent<Player>();
                    if (player != null)
                    {
                        player.TakeDamage(_config.Damage);
                        PlayerDamageTimer = TickTimer.CreateFromSeconds(Runner, _config.PlayerDamageCooldown);
                    }
                }

                var portal = collider.GetComponent<Portal>();
                if (portal != null)
                {
                    portal.TakeDamage(_config.Damage);
                    _deathComponent.IsDead = true;
                    return;
                }
            }
        }
    }
}