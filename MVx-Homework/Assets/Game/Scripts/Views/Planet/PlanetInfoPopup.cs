using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Views
{
    public sealed class PlanetInfoPopup : MonoBehaviour
    {
        [SerializeField] private TMP_Text _planetNameField;
        [SerializeField] private Image _planetIcon;
        [SerializeField] private TMP_Text _populationField;
        [SerializeField] private TMP_Text _levelField;
        [SerializeField] private TMP_Text _incomeField;
        [SerializeField] private Button _upgradeButton;
        [SerializeField] private Button _closeButton;
        [SerializeField] private TMP_Text _priceField;
        [SerializeField] private GameObject _upgradeContainer;
        [SerializeField] private TMP_Text _maxLevelField;
        
        private IPlanetPopupPresenter _presenter;

        public void Show(IPlanetPopupPresenter presenter)
        {
            _presenter = presenter;

            _upgradeButton.onClick.AddListener(_presenter.OnUpgradeClicked);
            _closeButton.onClick.AddListener(Hide);
            
            _presenter.OnStateChanged += UpdateView;
            _presenter.OnIncomeChanged += OnIncomeChanged;
            _presenter.OnPopulationChanged += OnPopulationChanged;
            _presenter.OnUpgraded += OnUpgraded;
            _presenter.Enable();
            
            gameObject.SetActive(true);
            UpdateView();
        }

        public void Hide()
        {
            _upgradeButton.onClick.RemoveListener(_presenter.OnUpgradeClicked);
            _closeButton.onClick.RemoveListener(Hide);

            _presenter.OnStateChanged -= UpdateView;
            _presenter.OnIncomeChanged -= OnIncomeChanged;
            _presenter.OnPopulationChanged -= OnPopulationChanged;
            _presenter.OnUpgraded -= OnUpgraded;
            _presenter.Disable();
            _presenter = null;
            
            gameObject.SetActive(false);
        }

        private void UpdateView()
        {
            _planetIcon.sprite = _presenter.PlanetIcon;
            _planetNameField.text = _presenter.PlanetName;
            _populationField.text = _presenter.Population;
            _levelField.text = _presenter.Level;
            _incomeField.text = _presenter.Income;
            _priceField.text = _presenter.Price;
            _upgradeButton.interactable = _presenter.CanUpgrade;
            _upgradeContainer.SetActive(_presenter.IsMaxLevel == false);
            _maxLevelField.gameObject.SetActive(_presenter.IsMaxLevel);
            _maxLevelField.text = _presenter.MaxLevel;
        }
        
        private void OnUpgraded()
        {
            _levelField.text = _presenter.Level;
            _priceField.text = _presenter.Price;
            _upgradeButton.interactable = _presenter.CanUpgrade;
            _upgradeContainer.SetActive(_presenter.IsMaxLevel == false);
            _maxLevelField.gameObject.SetActive(_presenter.IsMaxLevel);
            _maxLevelField.text = _presenter.MaxLevel;
        }

        private void OnPopulationChanged()
        {
            _populationField.text = _presenter.Population;
        }

        private void OnIncomeChanged()
        {
            _incomeField.text = _presenter.Income;
        }
    }
}