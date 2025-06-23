using Fusion;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Game
{
    public sealed class Enemy : NetworkBehaviour
    {
        [SerializeField] private HealthComponent _healthComponent;
        [SerializeField] private MoveComponent _moveComponent;
        [SerializeField] private RotationComponent _rotationComponent;
        [SerializeField] private CollisionComponent _collisionComponent;
        [SerializeField] private int _damage = 1;
        [SerializeField] private float _playerDamageCooldown = 1f;
        [SerializeField] private Vector2Int _reward;
        [SerializeField] private ParticleSpawner _deathParticle;

        [Networked] private TickTimer PlayerDamageTimer { get; set; }

        [Networked, OnChangedRender(nameof(OnDeadChanged))]
        private bool IsDead { get; set; }

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
            if (IsDead)
            {
                return;
            }

            if (_healthComponent.Exists() == false)
            {
                IsDead = true;
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
            var reward = Random.Range(_reward.x, _reward.y);
            _moneyStorage.Earn(reward);
        }

        private void MoveToPortal()
        {
            var direction = _target.transform.position - transform.position;
            var directionNormalized = direction.normalized;

            _moveComponent.MoveStep(directionNormalized, Runner.DeltaTime);
            _rotationComponent.RotateStep(directionNormalized, Runner.DeltaTime);
        }

        private void OnDeadChanged()
        {
            _deathParticle.Play();
            gameObject.SetActive(false);
        }

        private void OnCollided(Collider[] colliders, int count)
        {
            if (IsDead)
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
                        player.TakeDamage(_damage);
                        PlayerDamageTimer = TickTimer.CreateFromSeconds(Runner, _playerDamageCooldown);
                    }
                }

                var portal = collider.GetComponent<Portal>();
                if (portal != null)
                {
                    portal.TakeDamage(_damage);
                    IsDead = true;
                    return;
                }
            }
        }
    }
}