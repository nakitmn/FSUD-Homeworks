using System;
using Modules.Entity;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class TriggerEntityDetectorComponent : MonoBehaviour
    {
        public event Action<IEntity> OnDetected;

        private void OnTriggerEnter2D(Collider2D other)
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