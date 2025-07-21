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
            var result = EnemyUseCase.FindPathToTarget(gameContext, _source, target);
            Debug.Log($"Pathfinding:\n{string.Join("\n", result)}");
        }
    }
}