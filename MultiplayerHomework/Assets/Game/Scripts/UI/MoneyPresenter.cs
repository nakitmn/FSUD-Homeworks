using TMPro;
using UnityEngine;
using Zenject;

namespace Game
{
    public sealed class MoneyPresenter : MonoBehaviour
    {
        [SerializeField] private TMP_Text _amount;
        
        private MoneyStorage _moneyStorage;

        [Inject]
        public void Construct(MoneyStorage moneyStorage)
        {
            _moneyStorage = moneyStorage;
        }
        
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