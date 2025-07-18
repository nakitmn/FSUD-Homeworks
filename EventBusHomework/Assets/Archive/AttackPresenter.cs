/*using System;
using Atomic.Entities;
using Atomic.Events;
using SampleGame;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public sealed class AttackPresenter : MonoBehaviour
    {
        [SerializeField]
        private Button _attackButton;
        
        [SerializeField]
        private SceneEntity _source;

        [SerializeField]
        private SceneEntity _target;

        [SerializeField]
        private SceneEventBus _eventBus;

        private void OnEnable()
        {
            _attackButton.onClick.AddListener(this.OnAttackClick);
        }

        [Button]
        public void OnAttackClick()
        {
            _eventBus.InvokeAttackStarted(); //Input
            
            var characterAttackCommand = new CharacterAttackCommand(_source, _target);
            characterAttackCommand.Execute()
        }
    }
}*/