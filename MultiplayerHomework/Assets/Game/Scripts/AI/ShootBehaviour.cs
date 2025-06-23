using System;
using Fusion;
using UnityEngine;

namespace Game
{
    public sealed class ShootBehaviour : NetworkBehaviour
    {
        [SerializeField] private RotationComponent _rotationComponent;
        [SerializeField] private FireComponent _fireComponent;
        [SerializeField] private Transform _center;
        [SerializeField] private float _radius = 1;
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private QueryTriggerInteraction _triggerInteraction;
        
        [Networked] private NetworkObject Target { get; set; }
        
        private readonly Collider[] _buffer = new Collider[8];
        private Func<bool> _condition;

        public void SetCondition(Func<bool> condition)
        {
            _condition = condition;
        }
        
        public override void FixedUpdateNetwork()
        {
            if (_condition?.Invoke() == false)
            {
                return;
            }
            
            FindTarget();
            if (Target == null)
            {
                return;
            }
            
            var distance = Target.transform.position - transform.position;
            _rotationComponent.RotateStep(distance.normalized, Runner.DeltaTime);
            _fireComponent.Fire();
        }

        private void FindTarget()
        {
            var physicsScene = Runner.GetPhysicsScene();
            var count = physicsScene.OverlapSphere(
                _center.position,
                _radius,
                _buffer,
                _layerMask,
                _triggerInteraction
            );
            
            for (var i = 0; i < count; i++)
            {
                var collider = _buffer[i];
                
                var enemy = collider.GetComponent<Enemy>();
                if (enemy == null)
                {
                    continue;
                }
                
                if (enemy.IsDead)
                {
                    continue;
                }

                Target = enemy.Object;
                return;
            }
            
            Target = null;
        }

        private void OnDrawGizmos()
        {
            var prevColor = Gizmos.color;
            Gizmos.color = Color.red;
            
            if (_center)
            {
                Gizmos.DrawWireSphere(_center.position, _radius);
            }
            
            if (StateBufferIsValid && Target != null)
            {
                Gizmos.DrawSphere(Target.transform.position, 2f);
            }

            Gizmos.color = prevColor;
        }
    }
}