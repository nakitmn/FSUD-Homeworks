using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.UI
{
    public sealed class PlanetView : MonoBehaviour
    {
        [SerializeField] private Image _icon;
        [SerializeField] private GameObject _lockIcon;
        [SerializeField] private GameObject _incomeReadyMarker;
        [SerializeField] private CountdownView _progressView;
        [SerializeField] private GameObject _priceContainer;
        [SerializeField] private TMP_Text _price;

        public void SetIcon(Sprite icon)
        {
            _icon.sprite = icon;
        }

        public void SetLocked(bool lockIcon)
        {
            _lockIcon.SetActive(lockIcon);
        }

        public void SetIncomeReady(bool incomeReady)
        {
            _incomeReadyMarker.SetActive(incomeReady);
        }

        public void SetProgress(float progress)
        {
            _progressView.SetProgress(progress);
        }

        public void SetProgressText(string progress)
        {
            _progressView.SetProgressText(progress);
        }

        public void SetPriceEnabled(bool enabled)
        {
            _priceContainer.SetActive(enabled);
        }

        public void SetPrice(string price)
        {
            _price.text = price;
        }

        public void SetProgressEnabled(bool enabled)
        {
            if (enabled)
            {
                _progressView.Enable();
            }
            else
            {
                _progressView.Disable();
            }
        }
    }
}