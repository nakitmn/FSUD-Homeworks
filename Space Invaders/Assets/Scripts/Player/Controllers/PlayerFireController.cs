using Space_Ship;

namespace Player.Controllers
{
    public sealed class PlayerFireController
    {
        private readonly SpaceShip _ship;
        private readonly PlayerInput _playerInput;

        public PlayerFireController(SpaceShip ship, PlayerInput playerInput)
        {
            _ship = ship;
            _playerInput = playerInput;
        }

        public void Enable()
        {
            _playerInput.OnFireRequired += OnFireRequired;
        }

        public void Disable()
        {
            _playerInput.OnFireRequired -= OnFireRequired;
        }

        private void OnFireRequired()
        {
            _ship.Fire(_ship.FireForward);
        }
    }
}