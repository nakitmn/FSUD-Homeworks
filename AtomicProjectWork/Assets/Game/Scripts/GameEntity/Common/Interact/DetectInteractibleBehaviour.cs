using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace SampleGame
{
    public sealed class DetectInteractibleBehaviour : IInit<IGameEntity>, IFixedUpdate, IGizmos
    {
        private IReactiveVariable<IGameEntity> _target;

        private readonly Transform _center;
        private readonly float _radius;
        private readonly LayerMask _layerMask;
        private readonly QueryTriggerInteraction _triggerInteraction;
        private readonly Cooldown _period; 

        public DetectInteractibleBehaviour(
            Transform center,
            float radius,
            LayerMask layerMask,
            QueryTriggerInteraction triggerInteraction,
            Cooldown period
        )
        {
            _center = center;
            _radius = radius;
            _layerMask = layerMask;
            _triggerInteraction = triggerInteraction;
            _period = period;
        }

        public void Init(IGameEntity entity)
        {
            _target = entity.GetTargetInteractible();
        }

        public void OnFixedUpdate(in IEntity entity, in float deltaTime)
        {
            _period.Tick(deltaTime);
            if (!_period.IsExpired())
                return;

            InteractUseCase.FindClosest(_center.position, _radius, _layerMask, _triggerInteraction, out IGameEntity target);
            _target.Value = target;
            _period.Reset();
        }

        public void OnGizmosDraw(in IEntity entity)
        {
            Gizmos.DrawWireSphere(_center.position, _radius);
        }
    }
}