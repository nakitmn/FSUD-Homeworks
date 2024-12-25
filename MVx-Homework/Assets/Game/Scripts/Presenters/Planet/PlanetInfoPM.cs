using System;
using Game.Scripts.Views.Planet;
using UnityEngine;

namespace Game.Scripts.Presenters.Planet
{
    public sealed class PlanetInfoPM : IPlanetInfoPM
    {
        public event Action OnStateChanged;
        public event Action OnIncomeChanged;
        public event Action OnPopulationChanged;
        public event Action OnUpgraded;

        private readonly Modules.Planets.Planet _planet;

        public Sprite PlanetIcon => _planet.GetIcon(true);
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
            _planet.OnPopulationChanged += InvokePopulationChanged;
            _planet.OnUpgraded += InvokeUpgraded;
            _planet.OnIncomeChanged += InvokeIncomeChanged;
        }

        public void Disable()
        {
            _planet.OnPopulationChanged -= InvokePopulationChanged;
            _planet.OnUpgraded -= InvokeUpgraded;
            _planet.OnIncomeChanged -= InvokeIncomeChanged;
        }

        public void OnUpgradeClicked()
        {
            _planet.Upgrade();
        }

        private void InvokeIncomeChanged(int obj)
        {
            OnIncomeChanged?.Invoke();
        }

        private void InvokeUpgraded(int obj)
        {
            OnUpgraded?.Invoke();
        }

        private void InvokePopulationChanged(int obj)
        {
            OnPopulationChanged?.Invoke();
        }
    }
}