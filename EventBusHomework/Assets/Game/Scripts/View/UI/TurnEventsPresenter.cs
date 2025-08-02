using System;
using Atomic.Events;
using TMPro;
using UnityEngine;

namespace SampleGame
{
    public sealed class TurnEventsPresenter : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        
        private IEventBus _eventBus;

        private void Awake()
        {
            var gameContext = GameContext.Instance;
            _eventBus = gameContext.GetEventBus();
        }

        private void OnEnable()
        {
            _eventBus.SubscribeStartTurn(OnTurnStarted);
            _eventBus.SubscribeEndTurn(OnTurnEnded);
            _eventBus.SubscribeDamaged(OnDamaged);
        }

        private void OnDisable()
        {
            _eventBus.UnsubscribeStartTurn(OnTurnStarted);
            _eventBus.UnsubscribeEndTurn(OnTurnEnded);
            _eventBus.UnsubscribeDamaged(OnDamaged);
        }

        private void OnTurnEnded()
        {
            _text.text += $"\nTurn Ended!";
        }

        private void OnTurnStarted()
        {
            _text.text += $"\nTurn Started!";
        }

        private void OnDamaged(IGameEntity target, int damage)
        {
            _text.text += $"\n{target.Name} was damaged: {damage}";
        }
    }
}