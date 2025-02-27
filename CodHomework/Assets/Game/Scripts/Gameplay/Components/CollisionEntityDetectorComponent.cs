using System;
using Modules.Entity;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class CollisionEntityDetectorComponent : MonoBehaviour
    {
        public event Action<IEntity> OnDetected;

        private void OnCollisionEnter2D(Collision2D other)
        {
            var entity = other.gameObject.GetComponent<IEntity>();
            if (entity == null)
            {
                return;
            }
            
            OnDetected?.Invoke(entity);
        }
    }
}