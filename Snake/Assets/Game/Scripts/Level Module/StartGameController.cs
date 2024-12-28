using UnityEngine;
using Zenject;

namespace Level_Module
{
    public sealed class StartGameController : MonoBehaviour
    {
        private LevelManager _levelManager;

        [Inject]
        public void Construct(LevelManager levelManager)
        {
            _levelManager = levelManager;
        }

        private void Start()
        {
            _levelManager.StartGame();
        }
    }
}