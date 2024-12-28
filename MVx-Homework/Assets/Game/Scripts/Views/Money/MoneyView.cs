using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Game.Views
{
    public sealed class MoneyView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _amountField;
        [SerializeField] private RectTransform _iconPivot;
        [SerializeField] private float _counterDuration = 0.3f;

        private Tweener _counterAnimation;

        public RectTransform IconPivot => _iconPivot;

        public void SetAmount(string amount)
        {
            _amountField.text = amount;
        }

        public void PlayCounter(int from, int to)
        {
            if (_counterAnimation.IsActive())
            {
                _counterAnimation.Complete();
            }

            _counterAnimation = DOVirtual.Int(
                from,
                to,
                _counterDuration,
                newAmount => SetAmount(newAmount.ToString())
            );
        }
    }
}