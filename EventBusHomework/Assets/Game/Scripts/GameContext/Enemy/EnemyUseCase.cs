using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace SampleGame
{
    public static class EnemyUseCase
    {
        public static List<GameBoardPosition> FindPathToTarget(in IGameContext gameContext, in IGameEntity entity)
        {
            var target = entity.GetTarget().Value;
            return FindPathToTarget(gameContext, entity, target);
        }

        public static List<GameBoardPosition> FindPathToTarget(in IGameContext gameContext, in IGameEntity entity,
            in IGameEntity target)
        {
            var startPosition = GameBoardUseCase.GetBoardPosition(gameContext, entity);
            var endPosition = GameBoardUseCase.GetBoardPosition(gameContext, target);
            return PathfindingUseCase.FindPath(gameContext, startPosition, endPosition);
        }

        public static bool HasAliveEnemies(in IGameContext context)
        {
            var enemies = context.GetEnemies();
            return enemies.Exists(enemy => HealthUseCase.Exists(enemy));
        }

        public static void SelectRandomTarget(IGameContext context, IGameEntity entity)
        {
            var characters = context.GetCharacters();
            var aliveCharacters = characters.Where(x => HealthUseCase.Exists(x)).ToArray();
            entity.GetTarget().Value = aliveCharacters.Length > 0
                ? aliveCharacters[Random.Range(0, aliveCharacters.Length)]
                : null;
        }

        public static bool TrySpawnEnemies(IGameContext context)
        {
            if (WaveUseCase.TryGetCurrentWave(context, out var wave) == false)
            {
                return false;
            }

            var gameBoard = context.GetGameBoard();
            var enemies = context.GetEnemies();
            var spawnPoints = wave.points;
            var prefab = wave.prefab;

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
                    GameBoardUseCase.Set(context, enemyEntity, position);
                    enemies.Add(enemyEntity);
                }
            }

            return true;
        }

        public static async UniTask HandleEnemiesTurn(IGameContext context)
        {
            var enemies = context.GetEnemies();
            var animationQueue = context.GetAnimationQueue();

            foreach (IGameEntity enemy in enemies)
            {
                if (HealthUseCase.Exists(enemy) == false)
                {
                    continue;
                }

                SelectRandomTarget(context, enemy);
                var target = enemy.GetTarget().Value;
                if (target == null)
                {
                    continue;
                }

                var path = FindPathToTarget(context, enemy);
                var targetPosition = GameBoardUseCase.GetBoardPosition(context, target);
                var movePosition = path[0];

                var characterMoveCommand = new CharacterMoveCommand(enemy, movePosition);
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
    }
}