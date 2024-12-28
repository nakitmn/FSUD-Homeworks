using Game.Views;

namespace Game.Presenters
{
    public interface IPlanetPresenterFactory
    {
        PlanetPresenter Create(Modules.Planets.Planet planet, PlanetView view);
    }
}