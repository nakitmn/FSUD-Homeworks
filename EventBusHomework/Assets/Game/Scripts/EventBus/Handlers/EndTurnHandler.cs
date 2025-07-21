using Atomic.Entities;
using Atomic.Events;
using UnityEngine;

namespace SampleGame
{
    public sealed class EndTurnHandler : IInit<IGameContext>, IEnable, IDisable
    {
        private IEventBus _eventBus;
        private IGameContext _context;

        public void Init(IGameContext context)
        {
            _context = context;
            _eventBus = context.GetEventBus();
        }

        public void Enable(in IEntity entity)
        {
            _eventBus.SubscribeEndTurn(OnTurnEnd);
        }

        public void Disable(in IEntity entity)
        {
            _eventBus.UnsubscribeEndTurn(OnTurnEnd);
        }

        private void OnTurnEnd()
        {
            //TODO: AI logic
            SpawnEnemies(_context);
            _eventBus.InvokeStartTurn();
        }

        private void SpawnEnemies(IGameContext context)
        {
            var currentTurn = context.GetTurn().Value;
            var rate = context.GetSpawnTurnRate().Value;
            
            if (currentTurn % rate != 0)
            {
                return;
            }

            var gameBoard = context.GetGameBoard();
            var spawnPoints = context.GetSpawnPoints();
            foreach (var position in spawnPoints)
            {
                if (gameBoard.IsFree(position) == false)
                {
                    var entity = gameBoard[position];
                    var dealDamageCommand = new DealDamageCommand(entity, 1);
                    if (dealDamageCommand.Execute(context))
                    {
                        context.GetAnimationQueue().Execute();
                    }
                }
                else
                {
                    var prefab = context.GetEnemyPrefab().Value;
                    var enemyEntity = (IGameEntity) GameEntity.Create(prefab,Vector3.zero, Quaternion.identity);
                    GameBoardSetUseCase.Set(context, enemyEntity, position);
                }
            }
        }
    }
}