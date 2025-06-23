using System;
using Fusion;
using UnityEngine;

namespace Game
{
    public sealed class CollisionComponent : NetworkBehaviour
    {
        public event Action<Collider[], int> OnCollided;

        [SerializeField] private Transform _center;
        [SerializeField] private float _radius = 1;
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private QueryTriggerInteraction _triggerInteraction;
        [SerializeField] private Collider[] _buffer = new Collider[8];

        public override void FixedUpdateNetwork()
        {
            var count = Overlap(_radius, _buffer);

            if (count > 0)
            {
                OnCollided?.Invoke(_buffer, count);
            }
        }

        public int Overlap(float radius, Collider[] buffer)
        {
            var physicsScene = Runner.GetPhysicsScene();
            return physicsScene.OverlapSphere(
                _center.position,
                radius,
                buffer,
                _layerMask,
                _triggerInteraction
            );
        }

        public void DrawGizmos(float radius, Color? color = null)
        {
            var prevColor = Gizmos.color;
            
            if (color.HasValue)
            {
                Gizmos.color = color.Value;
            }
        
            if (_center)
            {
                Gizmos.DrawWireSphere(_center.position, radius);
            }

            Gizmos.color = prevColor;
        }

        private void OnDrawGizmos()
        {
            DrawGizmos(_radius);
        }
    }
}