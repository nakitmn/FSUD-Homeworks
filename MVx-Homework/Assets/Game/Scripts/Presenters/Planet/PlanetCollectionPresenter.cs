using System;
using System.Collections.Generic;
using Game.Views;
using Zenject;

namespace Game.Presenters
{
    public sealed class PlanetCollectionPresenter : IInitializable, IDisposable
    {
        private readonly IPlanetPresenterFactory _factory;
        private readonly Modules.Planets.Planet[] _planets;
        private readonly PlanetView[] _views;

        private readonly List<PlanetPresenter> _planetPresenters = new();

        public PlanetCollectionPresenter(IPlanetPresenterFactory factory, Modules.Planets.Planet[] planets,
            PlanetView[] views)
        {
            _factory = factory;
            _planets = planets;
            _views = views;
        }

        void IInitializable.Initialize()
        {
            for (var i = 0; i < _planets.Length; i++)
            {
                var planet = _planets[i];
                var view = _views[i];

                var planetPresenter = _factory.Create(planet, view);
                _planetPresenters.Add(planetPresenter);
                
                planetPresenter.Initialize();
            }
        }

        void IDisposable.Dispose()
        {
            _planetPresenters.ForEach(it => it.Dispose());
            _planetPresenters.Clear();
        }
    }
}