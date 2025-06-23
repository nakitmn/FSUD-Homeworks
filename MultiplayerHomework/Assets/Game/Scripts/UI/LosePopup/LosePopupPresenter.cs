using Fusion;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

namespace Game
{
    public sealed class LosePopupPresenter : MonoBehaviour
    {
        [SerializeField] private Button _menuButton;
        
        private NetworkRunner _networkRunner;

        [Inject]
        public void Construct(NetworkRunner networkRunner)
        {
            _networkRunner = networkRunner;
        }

        private void OnEnable()
        {
            _menuButton.onClick.AddListener(EnterMenu);
        }

        private void OnDisable()
        {
            _menuButton.onClick.RemoveListener(EnterMenu);
        }

        public void Enable()
        {
            gameObject.SetActive(true);
        }

        private void EnterMenu()
        {
            _networkRunner.Shutdown();
            SceneManager.LoadScene(0);
        }
    }
}