using DG.Tweening;
using TMPro;
using UnityEngine;

namespace SampleGame
{
    public sealed class TurnView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _caption;
        [SerializeField] private CanvasGroup _canvasGroup;

        public void SetCaption(string caption)
        {
            _caption.text = caption;
        }

        public Tween Enable()
        {
            gameObject.SetActive(true);
            _canvasGroup.alpha = 0f;
            return DOVirtual.Float(0f, 1f, 1f, value => _canvasGroup.alpha = value)
                .SetSpeedBased(true);
        }

        public Tween Disable()
        {
            return DOVirtual.Float(_canvasGroup.alpha, 0f, 1f, value => _canvasGroup.alpha = value)
                .SetSpeedBased(true)
                .OnComplete(() => gameObject.SetActive(false));
        }
    }
}