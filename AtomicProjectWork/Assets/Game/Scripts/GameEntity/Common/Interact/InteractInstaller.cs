using System;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace SampleGame
{
    [Serializable]
    public sealed class InteractInstaller : IEntityInstaller<IGameEntity>
    {
        [SerializeField]
        private Transform _center;
        
        [SerializeField]
        private float _radius;

        [SerializeField]
        private LayerMask _layerMask;

        [SerializeField]
        private QueryTriggerInteraction _triggerInteraction;

        [SerializeField]
        private float _period = 0.1f;
        
        public void Install(IGameEntity entity)
        {
            entity.AddTargetInteractible(new ReactiveVariable<IGameEntity>());
            entity.AddBehaviour(new DetectInteractibleBehaviour(_center, _radius, _layerMask, _triggerInteraction,
                new Cooldown(_period)));
            entity.AddBehaviour<InteractBehaviour>();
        }
    }
}