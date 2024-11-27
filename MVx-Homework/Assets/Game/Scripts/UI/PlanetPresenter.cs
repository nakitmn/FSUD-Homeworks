using System;
using Modules.Planets;
using Unity.VisualScripting;

namespace Game.Scripts.UI
{
    public sealed class PlanetPresenter : IInitializable, IDisposable
    {
        private readonly Planet _planet;
        private readonly PlanetView _planetView;

        public PlanetPresenter(Planet planet, PlanetView planetView)
        {
            _planet = planet;
            _planetView = planetView;
        }

        public void Initialize()
        {
            _planet.OnIncomeTimeChanged += OnIncomeTimeChanged;
            _planet.OnUnlocked += OnUnlocked;
            _planet.OnIncomeReady += OnIncomeReady;

            _planetView.OnClick += OnPlanetClicked;

            UpdateView();
        }

        public void Dispose()
        {
            _planet.OnIncomeTimeChanged -= OnIncomeTimeChanged;
            _planet.OnUnlocked -= OnUnlocked;
            _planet.OnIncomeReady -= OnIncomeReady;

            _planetView.OnClick -= OnPlanetClicked;
        }

        private void UpdateView()
        {
            _planetView.SetIcon(_planet.GetIcon(_planet.IsUnlocked));
            _planetView.SetLocked(_planet.IsUnlocked == false);
            _planetView.SetPriceEnabled(_planet.IsUnlocked == false);
            _planetView.SetPrice(_planet.Price.ToString());
            _planetView.SetIncomeReady(_planet.IsUnlocked && _planet.IsIncomeReady);
            _planetView.SetProgressEnabled(_planet.IsUnlocked && _planet.IsIncomeReady == false);
            _planetView.SetProgress(_planet.IncomeProgress);
        }

        private void OnPlanetClicked()
        {
            if (_planet.IsUnlocked)
            {
                _planet.GatherIncome();
            }
            else
            {
                _planet.Unlock();
            }
        }

        private void OnIncomeTimeChanged(float time)
        {
            UpdateView();
            _planetView.SetProgressText(time.ToString("N1"));
        }

        private void OnUnlocked()
        {
            UpdateView();
        }

        private void OnIncomeReady(bool obj)
        {
            UpdateView();
        }
    }
}