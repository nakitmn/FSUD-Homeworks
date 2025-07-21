using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SampleGame
{
    public sealed class PathfindingDebug : MonoBehaviour
    {
        [SerializeField] private GameEntity _source;

        [Button]
        public void Build(GameEntity target)
        {
            var gameContext = GameContext.Instance;
            var startPosition = GameBoardMoveUseCase.GetBoardPosition(gameContext, _source);
            var endPosition = GameBoardMoveUseCase.GetBoardPosition(gameContext, target);
            var result =
                PathfindingUseCase.FindPath(gameContext, startPosition, endPosition);
            Debug.Log($"Pathfinding:\n{string.Join("\n", result)}");
        }
    }
}