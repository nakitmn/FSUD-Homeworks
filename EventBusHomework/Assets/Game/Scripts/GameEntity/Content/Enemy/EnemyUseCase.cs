using System.Collections.Generic;

namespace SampleGame
{
    public static class EnemyUseCase
    {
        public static List<GameBoardPosition> FindPathToTarget(in IGameContext gameContext,in IGameEntity entity)
        {
            var target = entity.GetTarget().Value;
            return FindPathToTarget(gameContext, entity, target);
        }

        public static List<GameBoardPosition> FindPathToTarget(in IGameContext gameContext,in IGameEntity entity, in IGameEntity target)
        {
            var startPosition = GameBoardMoveUseCase.GetBoardPosition(gameContext, entity);
            var endPosition = GameBoardMoveUseCase.GetBoardPosition(gameContext, target);
            return PathfindingUseCase.FindPath(gameContext, startPosition, endPosition);
        }
    }
}