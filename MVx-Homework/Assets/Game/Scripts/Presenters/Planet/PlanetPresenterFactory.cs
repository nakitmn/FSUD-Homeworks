using Game.Views;
using Zenject;

namespace Game.Presenters
{
    public sealed class PlanetPresenterFactory : PlaceholderFactory<Modules.Planets.Planet, PlanetView, PlanetPresenter>, IPlanetPresenterFactory
    {
    }
}