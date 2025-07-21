using System.Linq;
using Atomic.Entities;
using Atomic.Events;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.XR;

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
            HandleAsync();
        }

        private async UniTaskVoid HandleAsync()
        {
            await HandleEnemies(_context);
            SpawnEnemies(_context);
            _eventBus.InvokeStartTurn();
        }

        private async UniTask HandleEnemies(IGameContext context)
        {
            var enemies = context.GetEnemies();
            var animationQueue = context.GetAnimationQueue();

            foreach (IGameEntity enemy in enemies)
            {
                SelectTarget(context, enemy);
                var target = enemy.GetTarget().Value;
                if (target == null)
                {
                    continue;
                }

                var position = GameBoardMoveUseCase.GetBoardPosition(context, target);
                var characterMoveCommand = new CharacterMoveCommand(enemy, position);
                if (characterMoveCommand.Execute(context))
                {
                    await UniTask.WaitWhile(() => animationQueue.IsActive);
                }

                var attackCommand = new CharacterAttackCommand(enemy, position);
                if (attackCommand.Execute(context))
                {
                    await UniTask.WaitWhile(() => animationQueue.IsActive);
                }
            }
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
            var enemies = context.GetEnemies();
            var prefab = context.GetEnemyPrefab().Value;

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
                    var enemyEntity = (IGameEntity) GameEntity.Create(prefab, Vector3.zero, Quaternion.identity);
                    GameBoardSetUseCase.Set(context, enemyEntity, position);
                    enemies.Add(enemyEntity);
                }
            }
        }

        private static void SelectTarget(IGameContext context, IGameEntity entity)
        {
            var characters = context.GetCharacters();
            var aliveCharacters = characters.Where(x => HealthUseCase.Exists(x)).ToArray();
            entity.GetTarget().Value = aliveCharacters.Length > 0
                ? aliveCharacters[Random.Range(0, aliveCharacters.Length)]
                : null;
        }
    }
}