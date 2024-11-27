using TMPro;
using UnityEngine;

namespace Game.Scripts.UI
{
    public sealed class MoneyView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _amountField;

        public void SetAmount(string amount)
        {
            _amountField.text = amount;
        }
    }
}