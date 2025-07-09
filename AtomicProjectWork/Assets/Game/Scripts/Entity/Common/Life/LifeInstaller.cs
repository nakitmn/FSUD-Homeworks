using System;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace SampleGame
{
    [Serializable]
    public class LifeInstaller : IEntityInstaller
    {
        [SerializeField] private int _health;

        public void Install(IEntity entity)
        {
            entity.AddDamageableTag();
            entity.AddDeathEvent(new BaseEvent());
            entity.AddDamagedEvent(new BaseEvent());
            entity.AddMaxHealth(new ReactiveVariable<int>(_health));
            entity.AddHealth(new ReactiveVariable<int>(_health));
            
            entity.AddBehaviour<DeathBehaviour>();
        }
    }
}