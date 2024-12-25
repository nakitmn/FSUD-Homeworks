using System;
using Game.Scripts.Presenters.Money;
using Game.Scripts.Views.Planet;
using Unity.VisualScripting;

namespace Game.Scripts.Presenters.Planet
{
    public sealed class PlanetPresenter : IInitializable, IDisposable
    {
        private readonly Modules.Planets.Planet _planet;
        private readonly PlanetView _planetView;
        private readonly MoneyFacade _moneyFacade;
        private readonly PlanetInfoPopup _planetInfoPopup;

        public PlanetPresenter(
            Modules.Planets.Planet planet,
            PlanetView planetView,
            MoneyFacade moneyFacade,
            PlanetInfoPopup planetInfoPopup
        )
        {
            _planet = planet;
            _planetView = planetView;
            _moneyFacade = moneyFacade;
            _planetInfoPopup = planetInfoPopup;
        }

        public void Initialize()
        {
            _planet.OnIncomeTimeChanged += OnIncomeTimeChanged;
            _planet.OnUnlocked += OnUnlocked;
            _planet.OnIncomeReady += OnIncomeReady;
            _planet.OnUpgraded += OnUpgraded;

            _planetView.OnClick += OnPlanetClicked;
            _planetView.OnHold += OnPlanetHold;

            UpdateView();
        }

        public void Dispose()
        {
            _planet.OnIncomeTimeChanged -= OnIncomeTimeChanged;
            _planet.OnUnlocked -= OnUnlocked;
            _planet.OnIncomeReady -= OnIncomeReady;
            _planet.OnUpgraded += OnUpgraded;

            _planetView.OnClick -= OnPlanetClicked;
            _planetView.OnHold -= OnPlanetHold;
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
                var income = _planet.MinuteIncome;
                if (_planet.GatherIncome())
                {
                    _moneyFacade.PlayCoin(_planetView.CoinPivot, income);
                }
            }
            else
            {
                if (_planet.Unlock())
                {
                    _moneyFacade.SyncWithCounter();
                }
            }
        }

        private void OnPlanetHold()
        {
            if (_planet.IsUnlocked == false)
            {
                return;
            }

            _planetInfoPopup.Show(new PlanetInfoPM(_planet));
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

        private void OnUpgraded(int obj)
        {
            _moneyFacade.SyncWithCounter();
        }
    }
}