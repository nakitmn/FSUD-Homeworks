using System;
using Modules.Entity;
using Modules.Health;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class DamagableEntityDetectorComponent : MonoBehaviour
    {
        public event Action<IEntity> OnDetected;

        private void OnCollisionEnter2D(Collision2D other)
        {
            var entity = other.gameObject.GetComponent<IEntity>();
            if (entity == null)
            {
                return;
            }
            
            if (entity.TryGet<Health>(out _))
            {
                OnDetected?.Invoke(entity);
            }
        }
    }
}