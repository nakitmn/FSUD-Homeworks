using System;
using Common.Interfaces;
using UnityEngine;

namespace Bullets
{
    public sealed class Bullet : MonoBehaviour
    {
        public event Action<Bullet, Collision2D> OnCollisionEntered;

        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private SpriteRenderer _spriteRenderer;

        private int _damage;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            DealDamage(collision.gameObject);
            OnCollisionEntered?.Invoke(this, collision);
        }

        public void SetParams(BulletParams bulletParams)
        {
            transform.position = bulletParams.Position;
            gameObject.layer = bulletParams.PhysicsLayer;
            _spriteRenderer.color = bulletParams.Color;
            _damage = bulletParams.Damage;
            _rigidbody2D.velocity = bulletParams.Velocity;
        }

        private void DealDamage(GameObject other)
        {
            if (_damage <= 0)
            {
                return;
            }

            if (other.TryGetComponent(out IDamagable damagable))
            {
                damagable.TakeDamage(_damage);
            }
        }
    }
}