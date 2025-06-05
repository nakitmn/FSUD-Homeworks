using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Game
{
    public sealed class MenuPresenter : MonoBehaviour
    {
        [SerializeField] private Button _playButton;
        [SerializeField] private int _sceneIndex = 1;

        private void OnEnable()
        {
            _playButton.onClick.AddListener(Play);
        }

        private void OnDisable()
        {
            _playButton.onClick.RemoveListener(Play);
        }

        private void Play()
        {
            SceneManager.LoadScene(_sceneIndex);
        }
    }
}