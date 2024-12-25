using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.Views.Planet
{
    public sealed class PlanetInfoPopup : MonoBehaviour
    {
        [SerializeField] private TMP_Text _planetNameField;
        [SerializeField] private TMP_Text _populationField;
        [SerializeField] private TMP_Text _levelField;
        [SerializeField] private TMP_Text _incomeField;
        [SerializeField] private Button _upgradeButton;
        [SerializeField] private Button _closeButton;
        [SerializeField] private TMP_Text _priceField;

        private IPlanetInfoPM _pm;

        public void Show(IPlanetInfoPM pm)
        {
            _pm = pm;

            _upgradeButton.onClick.AddListener(_pm.OnUpgradeClicked);
            _closeButton.onClick.AddListener(Hide);

            _pm.OnStateChanged += UpdateView;

            _pm.Enable();
            gameObject.SetActive(true);
            UpdateView();
        }

        public void Hide()
        {
            _upgradeButton.onClick.RemoveListener(_pm.OnUpgradeClicked);
            _closeButton.onClick.RemoveListener(Hide);

            _pm.OnStateChanged -= UpdateView;

            _pm.Disable();
            _pm = null;
            
            gameObject.SetActive(false);
        }

        private void UpdateView()
        {
            _planetNameField.text = _pm.PlanetName;
            _populationField.text = _pm.Population;
            _levelField.text = _pm.Level;
            _incomeField.text = _pm.Income;
            _priceField.text = _pm.Price;
            _upgradeButton.interactable = _pm.CanUpgrade;
        }
    }
}