using TMPro;
using UnityEngine;

namespace Game
{
    public sealed class MoneyPresenter : MonoBehaviour
    {
        [SerializeField] private MoneyStorage _moneyStorage;
        [SerializeField] private TMP_Text _amount;

        private void OnEnable()
        {
            _moneyStorage.OnMoneyChanged += OnMoneyChanged;
        }

        private void OnDisable()
        {
            _moneyStorage.OnMoneyChanged -= OnMoneyChanged;
        }

        private void OnMoneyChanged()
        {
            _amount.text = _moneyStorage.Money.ToString();
        }
    }
}