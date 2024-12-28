using Modules;
using UnityEngine;
using Zenject;

namespace Level_Module
{
    public sealed class StartGameController : MonoBehaviour
    {
        private GameCycle _gameCycle;
        private IDifficulty _difficulty;

        [Inject]
        public void Construct(GameCycle gameCycle, IDifficulty difficulty)
        {
            _difficulty = difficulty;
            _gameCycle = gameCycle;
        }

        private void Start()
        {
            _gameCycle.StartGame();
            _difficulty.Next(out _);
        }
    }
}