using Fusion;
using UnityEngine;

namespace Game
{
    public sealed class Mine : NetworkBehaviour
    {
        [SerializeField] private CollisionComponent _collisionComponent;
        [SerializeField] private float _explodeRadius = 1f;
        [SerializeField] private int _damage = 1;
        [SerializeField] private ParticleSpawner _explosionEffect;

        [Networked, OnChangedRender(nameof(OnExploded))]
        private bool IsExploded { get; set; }

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
            for (var i = 0; i < count; i++)
            {
                var collider = colliders[i];
                var enemy = collider.GetComponent<Enemy>();
                if (enemy != null)
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
                var enemy = collider.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.TakeDamage(_damage);
                }
            }

            IsExploded = true;
        }

        private void OnExploded()
        {
            _explosionEffect.Play();
            gameObject.SetActive(false);
        }

        private void OnDrawGizmos()
        {
            _collisionComponent.DrawGizmos(_explodeRadius, Color.red);
        }
    }
}