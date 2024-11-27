using System;
using System.Collections.Generic;
using Game.Scripts.UI;
using Modules.Planets;
using Zenject;

namespace Game.Scripts
{
    public sealed class PlanetPresentersLinker : IInitializable, IDisposable
    {
        private readonly DiContainer _container;
        private readonly Planet[] _planets;
        private readonly PlanetView[] _views;

        private readonly List<PlanetPresenter> _planetPresenters = new();

        public PlanetPresentersLinker(DiContainer container, Planet[] planets, PlanetView[] views)
        {
            _container = container;
            _planets = planets;
            _views = views;
        }

        void IInitializable.Initialize()
        {
            for (var i = 0; i < _planets.Length; i++)
            {
                var planet = _planets[i];
                var view = _views[i];

                var planetPresenter = _container.Instantiate<PlanetPresenter>(new object[] { planet, view });
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