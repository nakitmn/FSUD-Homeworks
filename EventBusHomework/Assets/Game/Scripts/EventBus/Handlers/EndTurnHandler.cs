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
            HandleAsync();
        }

        private async UniTaskVoid HandleAsync()
        {
            await HandleEnemies(_context);
            SpawnEnemies(_context);
            _context.GetTurn().Value++;
            _eventBus.InvokeStartTurn();
        }

        private async UniTask HandleEnemies(IGameContext context)
        {
            var enemies = context.GetEnemies();
            var animationQueue = context.GetAnimationQueue();

            foreach (IGameEntity enemy in enemies)
            {
                if (HealthUseCase.Exists(enemy) == false)
                {
                    continue;
                }
                
                SelectTarget(context, enemy);
                var target = enemy.GetTarget().Value;
                if (target == null)
                {
                    continue;
                }

                var targetPosition = GameBoardMoveUseCase.GetBoardPosition(context, target);
                var characterMoveCommand = new CharacterMoveCommand(enemy, targetPosition);
                if (characterMoveCommand.Execute(context))
                {
                    await UniTask.WaitWhile(() => animationQueue.IsActive);
                }

                var attackCommand = new CharacterAttackCommand(enemy, targetPosition);
                if (attackCommand.Execute(context))
                {
                    await UniTask.WaitWhile(() => animationQueue.IsActive);
                }
            }
        }

        private void SpawnEnemies(IGameContext context)
        {
            if (TryGetCurrentWave(context, out var wave) == false)
            {
                return;
            }

            var gameBoard = context.GetGameBoard();
            var spawnPoints = wave.points;
            var prefab = wave.prefab;
            var enemies = context.GetEnemies();

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

        private bool TryGetCurrentWave(IGameContext context, out SpawnWave currentWave)
        {
            var currentTurn = context.GetTurn().Value;
            var waves = context.GetWaves();

            foreach (var wave in waves)
            {
                if (wave.turn == currentTurn)
                {
                    currentWave = wave;
                    return true;
                }
            }

            currentWave = default;
            return false;
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