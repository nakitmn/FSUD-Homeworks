using Level;
using Space_Ship;
using UnityEngine;

namespace Player.Controllers
{
    public class PlayerClampInBoundsController
    {
        private readonly SpaceShip _ship;
        private readonly LevelBounds _levelBounds;

        public PlayerClampInBoundsController(SpaceShip ship, LevelBounds levelBounds)
        {
            _ship = ship;
            _levelBounds = levelBounds;
        }

        public void Update()
        {
            Vector3 currentPosition = _ship.transform.position;
            Vector2 clampedPosition = _levelBounds.ClampInBounds(currentPosition);
            _ship.transform.position = clampedPosition;
        }
    }
}