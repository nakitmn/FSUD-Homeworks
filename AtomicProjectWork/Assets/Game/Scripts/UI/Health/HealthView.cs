using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SampleGame
{
    public sealed class HealthView : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _text;

        [SerializeField]
        private Image[] _fillImages;

        [SerializeField] private RectTransform _border;
        
        public void SetValue(string text)
        {
            _text.text = text;
        }

        public void SetProgress(float progress)
        {
            var anchorMin = _border.anchorMin;
            anchorMin.y = progress;
            var anchorMax = _border.anchorMax;
            anchorMax.y = progress;
            _border.anchorMin = anchorMin;
            _border.anchorMax = anchorMax;
            
            foreach (var fillImage in _fillImages)
            {
                fillImage.fillAmount = progress;
            }
        }
    }
}