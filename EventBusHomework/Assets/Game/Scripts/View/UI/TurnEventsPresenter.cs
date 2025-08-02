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
            _eventBus.SubscribeAttack(OnAttack);
            _eventBus.SubscribeMoved(OnMoved);

            _eventBus.SubscribePushedOut(OnPushedOut);
            _eventBus.SubscribePushedInTarget(OnPushedInTarget);
            _eventBus.SubscribePushed(OnPushed);

            _eventBus.SubscribeDied(OnDied);
        }

        private void OnDisable()
        {
            _eventBus.UnsubscribeStartTurn(OnTurnStarted);
            _eventBus.UnsubscribeEndTurn(OnTurnEnded);
            _eventBus.UnsubscribeDamaged(OnDamaged);
            _eventBus.UnsubscribeAttack(OnAttack);
            _eventBus.UnsubscribeMoved(OnMoved);

            _eventBus.UnsubscribePushedOut(OnPushedOut);
            _eventBus.UnsubscribePushedInTarget(OnPushedInTarget);
            _eventBus.UnsubscribePushed(OnPushed);
            
            _eventBus.UnsubscribeDied(OnDied);
        }

        private void OnDied(IGameEntity target)
        {
            _text.text += $"\n{target.Name} was died!";
        }

        private void OnPushed(IGameEntity target, GameBoardPosition startPosition, Vector2Int direction)
        {
            _text.text += $"\n{target.Name} was pushed to {startPosition + direction}!";
        }

        private void OnPushedInTarget(IGameEntity pushedEntity, IGameEntity target)
        {
            _text.text += $"\n{pushedEntity.Name} bounds with {target.Name}!";
        }

        private void OnPushedOut(IGameEntity target, GameBoardPosition startPosition, Vector2Int direction)
        {
            _text.text += $"\n{target.Name} was pushed out!";
        }

        private void OnMoved(IGameEntity entity, GameBoardPosition position)
        {
            _text.text += $"\n{entity.Name} moved to {position}";
        }

        private void OnTurnEnded()
        {
            _text.text += $"\nTurn Ended!";
        }

        private void OnAttack(IGameEntity target, IGameEntity source)
        {
            _text.text += $"\n{target.Name} attacks {source.Name}";
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