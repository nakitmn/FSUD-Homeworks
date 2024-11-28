using System;
using Modules.Planets;

namespace Game.Scripts.UI
{
    public sealed class PlanetInfoPM : IPlanetInfoPM
    {
        public event Action OnStateChanged;

        private readonly Planet _planet;

        public string PlanetName => _planet.Name;
        public string Population => $"Population: {_planet.Population}";
        public string Level => $"Level: {_planet.Level}/{_planet.MaxLevel}";
        public string Income => $"Income: {_planet.MinuteIncome}/sec";
        public string Price => _planet.Price.ToString();
        public bool CanUpgrade => _planet.CanUpgrade;

        public PlanetInfoPM(Planet planet)
        {
            _planet = planet;
        }

        public void Enable()
        {
            _planet.OnPopulationChanged += OnPopulationChanged;
            _planet.OnUpgraded += OnUpgraded;
            _planet.OnIncomeChanged += OnIncomeChanged;
        }

        public void Disable()
        {
            _planet.OnPopulationChanged -= OnPopulationChanged;
            _planet.OnUpgraded -= OnUpgraded;
            _planet.OnIncomeChanged -= OnIncomeChanged;
        }

        public void OnUpgradeClicked()
        {
            _planet.Upgrade();
        }

        private void OnIncomeChanged(int obj)
        {
            OnStateChanged?.Invoke();
        }

        private void OnUpgraded(int obj)
        {
            OnStateChanged?.Invoke();
        }

        private void OnPopulationChanged(int obj)
        {
            OnStateChanged?.Invoke();
        }
    }
}