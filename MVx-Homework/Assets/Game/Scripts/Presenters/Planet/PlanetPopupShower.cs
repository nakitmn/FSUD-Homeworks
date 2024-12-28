using Game.Views;

namespace Game.Presenters
{
    public sealed class PlanetPopupShower
    {
        private readonly PlanetInfoPopup _popup;
        private readonly PlanetPopupPresenter _presenter;

        public PlanetPopupShower(PlanetInfoPopup popup, PlanetPopupPresenter presenter)
        {
            _popup = popup;
            _presenter = presenter;
        }
        
        public void Show(Modules.Planets.Planet planet)
        {
            _presenter.Init(planet);
            _popup.Show(_presenter);
        }
    }
}