using Fusion;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Game
{
    public sealed class LosePopup : MonoBehaviour
    {
        [SerializeField] private Button _menuButton;
        [SerializeField] private NetworkRunner _networkRunner;

        private void OnEnable()
        {
            _menuButton.onClick.AddListener(EnterMenu);
        }

        private void OnDisable()
        {
            _menuButton.onClick.RemoveListener(EnterMenu);
        }

        private void EnterMenu()
        {
            _networkRunner.Shutdown();
            SceneManager.LoadScene(0);
        }
    }
}