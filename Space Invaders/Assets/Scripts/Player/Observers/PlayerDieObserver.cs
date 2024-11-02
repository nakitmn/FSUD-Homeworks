using Space_Ship;
using UnityEngine;

namespace Player.Observers
{
    public sealed class PlayerDieObserver
    {
        private readonly SpaceShip _ship;

        public PlayerDieObserver(SpaceShip ship)
        {
            _ship = ship;
        }

        public void Enable()
        {
            _ship.OnDeath += OnPlayerDied;
        }

        public void Disable()
        {
            _ship.OnDeath -= OnPlayerDied;
        }

        private void OnPlayerDied()
        {
            Time.timeScale = 0;
        }
    }
}