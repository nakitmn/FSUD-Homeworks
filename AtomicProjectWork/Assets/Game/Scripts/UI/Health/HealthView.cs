using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SampleGame
{
    public sealed class HealthView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        [SerializeField] private Image[] _fillImages;
        [SerializeField] private RectTransform _border;
        [SerializeField] private float _smoothDuration = 0.5f;

        private Sequence _sequence;

        public void SetValue(string text)
        {
            _text.text = text;
        }

        public void SetProgress(float progress)
        {
            if (_sequence.IsActive())
            {
                _sequence.Kill();
            }

            _sequence = DOTween.Sequence();
            _sequence.SetLink(gameObject);

            _sequence.Join(
                DOVirtual.Float(_border.anchorMin.y, progress, _smoothDuration / 2f, value =>
                {
                    var anchorMin = _border.anchorMin;
                    anchorMin.y = value;
                    var anchorMax = _border.anchorMax;
                    anchorMax.y = value;
                    _border.anchorMin = anchorMin;
                    _border.anchorMax = anchorMax;
                })
            );

            foreach (var fillImage in _fillImages)
            {
                _sequence.Join(
                    fillImage.DOFillAmount(progress, _smoothDuration)
                );
            }
        }
    }
}