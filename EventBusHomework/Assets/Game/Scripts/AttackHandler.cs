/*using System;
using System.Collections.Generic;
using Atomic.Entities;
using Atomic.Events;
using SampleGame;
using UnityEngine;

namespace DefaultNamespace
{
    public sealed class AttackHandler : MonoBehaviour
    {
        [SerializeField]
        private SceneEventBus _eventBus; //UI
        
        private void OnEnable() => _eventBus.SubscribeAttack(this.OnAttack);

        private void OnDisable() => _eventBus.UnsubscribeAttack(this.OnAttack);

        private void OnAttack(IEntity source, IEntity target)
        {
            //Deal damage
            int damage = source.GetDamage();
            int health = target.GetHealth();
            target.SetHealth(health - damage);
            
            _eventBus.InvokeDealDamage(source, target);
        }
    }
}*/