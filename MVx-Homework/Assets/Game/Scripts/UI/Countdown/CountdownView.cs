using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.UI.Countdown
{
    public sealed class CountdownView : MonoBehaviour
    {
        [SerializeField] private Image _progressBar;
        [SerializeField] private TMP_Text _progressField;

        public void Enable()
        {
            gameObject.SetActive(true);
        }
        
        public void Disable()
        {
            gameObject.SetActive(false);
        }

        public void SetProgress(float progress)
        {
            _progressBar.fillAmount = progress;
        }
        
        public void SetProgressText(string progress)
        {
            _progressField.text = progress;
        }
    }
}