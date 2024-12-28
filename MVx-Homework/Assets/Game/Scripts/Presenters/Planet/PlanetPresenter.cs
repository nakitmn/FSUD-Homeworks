using System;
using Game.Views;
using Zenject;

namespace Game.Presenters
{
    public sealed class PlanetPresenter : IInitializable, IDisposable
    {
        private readonly Modules.Planets.Planet _planet;
        private readonly PlanetView _planetView;
        private readonly MoneyPresenter _moneyPresenter;
        private readonly PlanetPopupShower _popupShower;

        public PlanetPresenter(
            Modules.Planets.Planet planet,
            PlanetView planetView,
            MoneyPresenter moneyPresenter,
            PlanetPopupShower popupShower
        )
        {
            _planet = planet;
            _planetView = planetView;
            _moneyPresenter = moneyPresenter;
            _popupShower = popupShower;
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
                    _moneyPresenter.PlayCoin(_planetView.CoinPivot, income);
                }
            }
            else
            {
                if (_planet.Unlock())
                {
                    _moneyPresenter.SyncWithCounter();
                }
            }
        }

        private void OnPlanetHold()
        {
            if (_planet.IsUnlocked == false)
            {
                return;
            }

            _popupShower.Show(_planet);
        }

        private void OnIncomeTimeChanged(float time)
        {
            UpdateView();
            var timeSpan = TimeSpan.FromSeconds(time + 1);
            _planetView.SetProgressText(timeSpan.ToString(@"mm\:ss"));
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
            _moneyPresenter.SyncWithCounter();
        }
    }
}