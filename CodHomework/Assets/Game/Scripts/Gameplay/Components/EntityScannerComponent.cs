using System.Collections.Generic;
using Modules.Entity;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class EntityScannerComponent : MonoBehaviour
    {
        [SerializeField] private Transform _scanOrigin;
        [SerializeField] private float _radius;

        private readonly Collider2D[] _collidersBuffer = new Collider2D[8];

        public List<IEntity> ScanMultiple()
        {
            var result = new List<IEntity>();

            var collidersCount = Physics2D.OverlapCircleNonAlloc(_scanOrigin.position, _radius, _collidersBuffer);
            for (var i = 0; i < collidersCount; i++)
            {
                var collider = _collidersBuffer[i];
                var entity = collider.GetComponent<IEntity>();
                if (entity != null && result.Contains(entity) == false)
                {
                    result.Add(entity);
                }
            }
            
            return result;
        }
    }
}