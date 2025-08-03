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
            _eventBus.SubscribeStartPlayerTurn(OnPlayerTurnStarted);
            _eventBus.SubscribeEndPlayerTurn(OnPlayerTurnEnded);
            _eventBus.SubscribeStartEnemyTurn(OnEnemyTurnStarted);
            _eventBus.SubscribeEndEnemyTurn(OnEnemyTurnEnded);
            _eventBus.SubscribeDamaged(OnDamaged);
            _eventBus.SubscribeAttackStarted(OnAttackStarted);
            _eventBus.SubscribeAttackEnded(OnAttackEnded);
            _eventBus.SubscribeMoved(OnMoved);

            _eventBus.SubscribePushedOut(OnPushedOut);
            _eventBus.SubscribePushedInTarget(OnPushedInTarget);
            _eventBus.SubscribePushed(OnPushed);

            _eventBus.SubscribeDied(OnDied);
            _eventBus.SubscribeSpawned(OnSpawned);
        }

        private void OnDisable()
        {
            _eventBus.UnsubscribeStartPlayerTurn(OnPlayerTurnStarted);
            _eventBus.UnsubscribeEndPlayerTurn(OnPlayerTurnEnded);
            _eventBus.UnsubscribeStartEnemyTurn(OnEnemyTurnStarted);
            _eventBus.UnsubscribeEndEnemyTurn(OnEnemyTurnEnded);
            _eventBus.UnsubscribeDamaged(OnDamaged);
            _eventBus.UnsubscribeAttackStarted(OnAttackStarted);
            _eventBus.UnsubscribeAttackEnded(OnAttackEnded);
            _eventBus.UnsubscribeMoved(OnMoved);

            _eventBus.UnsubscribePushedOut(OnPushedOut);
            _eventBus.UnsubscribePushedInTarget(OnPushedInTarget);
            _eventBus.UnsubscribePushed(OnPushed);

            _eventBus.UnsubscribeDied(OnDied);
            _eventBus.UnsubscribeSpawned(OnSpawned);
        }

        private void OnSpawned(IGameEntity entity, GameBoardPosition position)
        {
            _text.text += $"\n{entity.Name}({entity.Id}) was spawned at {position}";
        }

        private void OnDied(IGameEntity target)
        {
            _text.text += $"\n{target.Name}({target.Id}) was died!";
        }

        private void OnPushed(IGameEntity target, GameBoardPosition startPosition, Vector2Int direction)
        {
            _text.text += $"\n{target.Name}({target.Id}) was pushed to {startPosition + direction}!";
        }

        private void OnPushedInTarget(PushInTargetEventData pushData)
        {
            _text.text += $"\n{pushData.Source.Name}({pushData.Source.Id}) bounds with {pushData.Target.Name}({pushData.Target.Id})!";
        }

        private void OnPushedOut(IGameEntity target, GameBoardPosition startPosition, Vector2Int direction)
        {
            _text.text += $"\n{target.Name}({target.Id}) was pushed out!";
        }

        private void OnMoved(IGameEntity entity, GameBoardPosition position)
        {
            _text.text += $"\n{entity.Name}({entity.Id}) moved to {position}";
        }

        private void OnAttackStarted(AttackEventData attackData)
        {
            _text.text += $"\n{attackData.Source.Name}({attackData.Source.Id}) start attack {attackData.Target.Name}({attackData.Target.Id})";
        }

        private void OnAttackEnded(AttackEventData attackData)
        {
            _text.text += $"\n{attackData.Source.Name}({attackData.Source.Id}) completed attack {attackData.Target.Name}({attackData.Target.Id})";
        }

        private void OnPlayerTurnStarted()
        {
            _text.text += $"\nPlayer turn started!";
        }

        private void OnPlayerTurnEnded()
        {
            _text.text += $"\nPlayer turn ended!";
        }

        private void OnEnemyTurnEnded()
        {
            _text.text += $"\nEnemy turn ended!";
        }

        private void OnEnemyTurnStarted()
        {
            _text.text += $"\nEnemy turn started!";
        }

        private void OnDamaged(IGameEntity target, int damage)
        {
            _text.text += $"\n{target.Name}({target.Id}) was damaged: {damage}";
        }
    }
}