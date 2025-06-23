using Fusion;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
    public sealed class EntryPoint : MonoBehaviour
    {
        [SerializeField]
        private NetworkRunner _networkRunner;

        [SerializeField]
        private NetworkSceneManagerDefault _sceneManager;

        [SerializeField] 
        private PoolableNetworkObjectProvider _networkObjectProvider;
        
        private void Start()
        {
            _networkRunner.StartGame(new StartGameArgs
            {
                GameMode = GameMode.AutoHostOrClient,
                SessionName = "SampleSession",
                Scene = SceneRef.FromIndex(SceneManager.GetActiveScene().buildIndex),
                SceneManager = _sceneManager,
                ObjectProvider = _networkObjectProvider
            });
        }
    }
}