using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SampleGame
{
    public static class EnemyUseCase
    {
        public static List<GameBoardPosition> FindPathToTarget(IGameContext gameContext, IGameEntity entity)
        {
            var target = entity.GetTarget().Value;
            return FindPathToTarget(gameContext, entity, target);
        }

        public static List<GameBoardPosition> FindPathToTarget(IGameContext gameContext, IGameEntity entity,
            in IGameEntity target)
        {
            var startPosition = GameBoardUseCase.GetBoardPosition(gameContext, entity);
            var endPosition = GameBoardUseCase.GetBoardPosition(gameContext, target);
            return PathfindingUseCase.FindPath(gameContext, startPosition, endPosition);
        }

        public static bool HasAliveEnemies(IGameContext context)
        {
            var enemies = CharacterTurnUseCase.GetEnemyCharacters(context);
            return HealthUseCase.HasAliveEntities(enemies);
        }

        public static void SelectRandomTarget(IGameContext context, IGameEntity entity)
        {
            var characters = CharacterTurnUseCase.GetPlayerCharacters(context);
            ;
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
            var enemies = CharacterTurnUseCase.GetEnemyCharacters(context);
            var spawnPoints = wave.points;

            foreach (var position in spawnPoints)
            {
                if (gameBoard.IsFree(position) == false)
                {
                    var entity = gameBoard[position];
                    var dealDamageCommand = new DealDamageCommand(entity, 1);
                    dealDamageCommand.Execute(context);
                }
                else
                {
                    SpawnEntityUseCase.Spawn(context, wave.prefab, position);
                }
            }

            return true;
        }

        public static void HandleEnemiesTurn(IGameContext context)
        {
            var enemies = CharacterTurnUseCase.GetEnemyCharacters(context);

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
                characterMoveCommand.Execute(context);
                var attackCommand = new CharacterAttackCommand(enemy, targetPosition);
                attackCommand.Execute(context);
            }
        }
    }
}