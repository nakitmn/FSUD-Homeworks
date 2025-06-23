using Fusion;
using UnityEngine;

namespace Game
{
    public sealed class Mine : NetworkBehaviour
    {
        [SerializeField] private DeathComponent _deathComponent;
        [SerializeField] private CollisionComponent _collisionComponent;
        [SerializeField] private float _explodeRadius = 1f;
        [SerializeField] private int _damage = 1;

        private readonly Collider[] _buffer = new Collider[8];

        public override void Spawned()
        {
            _collisionComponent.OnCollided += OnCollided;
        }

        public override void Despawned(NetworkRunner runner, bool hasState)
        {
            _collisionComponent.OnCollided -= OnCollided;
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
                if (collider.CompareTag(Tags.Enemy))
                {
                    Explode();
                    return;
                }
            }
        }

        private void Explode()
        {
            var count = _collisionComponent.Overlap(_explodeRadius, _buffer);
            for (var i = 0; i < count; i++)
            {
                var collider = _buffer[i];
                if (collider.CompareTag(Tags.Enemy))
                {
                    var healthComponent = collider.GetComponent<HealthComponent>();
                    healthComponent.TakeDamage(_damage);
                }
            }

            _deathComponent.IsDead = true;
        }

        private void OnDrawGizmos()
        {
            _collisionComponent.DrawGizmos(_explodeRadius, Color.red);
        }
    }
}