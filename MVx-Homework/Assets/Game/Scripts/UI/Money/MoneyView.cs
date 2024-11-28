using TMPro;
using UnityEngine;

namespace Game.Scripts.UI.Money
{
    public sealed class MoneyView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _amountField;
        [SerializeField] private RectTransform _iconPivot;

        public RectTransform IconPivot => _iconPivot;

        public void SetAmount(string amount)
        {
            _amountField.text = amount;
        }
    }
}