using Sirenix.OdinInspector;
using UnityEngine;

namespace SampleGame
{
    public sealed class GameBoardTest : MonoBehaviour
    {
        private GameContext _gameContext;

        private void Awake()
        {
            _gameContext = GameContext.Instance;
        }

        [Button]
        public void Set(GameEntity entity, int x, int y)
        {
            GameBoardSetUseCase.Set(_gameContext, entity, x, y);
        }
    }
}