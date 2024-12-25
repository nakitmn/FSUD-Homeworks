using System;
using Game.Scripts.Views.Planet;

namespace Game.Scripts.Presenters.Planet
{
    public sealed class PlanetInfoPM : IPlanetInfoPM
    {
        public event Action OnStateChanged;

        private readonly Modules.Planets.Planet _planet;

        public string PlanetName => _planet.Name;
        public string Population => $"Population: {_planet.Population}";
        public string Level => $"Level: {_planet.Level}/{_planet.MaxLevel}";
        public string Income => $"Income: {_planet.MinuteIncome}/sec";
        public string Price => _planet.Price.ToString();
        public bool CanUpgrade => _planet.CanUpgrade;
        public bool IsMaxLevel => _planet.IsMaxLevel;

        public PlanetInfoPM(Modules.Planets.Planet planet)
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