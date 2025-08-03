using Atomic.Entities;
using SampleGame;
using UnityEngine;

namespace Game
{
    [DefaultExecutionOrder(-100)]
    public sealed class EntryPoint : MonoBehaviour
    {
        [SerializeField] private GameContextInstaller _gameContextInstaller;
        [SerializeField] private SceneEntityWorld _entityWorld;
        [SerializeField] private EntityWorldView _view;
        
        private GameContext _gameContext;

        private void Awake()
        {
            _gameContext = GameContext.Instance;
            _gameContext.AddEntityWorld(_entityWorld);
            _gameContextInstaller.Install(_gameContext);

            _entityWorld.Add(_gameContext);
        }
    }
}