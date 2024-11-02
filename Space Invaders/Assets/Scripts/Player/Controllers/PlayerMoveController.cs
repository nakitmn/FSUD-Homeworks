using Level;
using Space_Ship;
using UnityEngine;

namespace Player.Controllers
{
    public sealed class PlayerMoveController 
    {
        private readonly SpaceShip _ship;
        private readonly PlayerInput _playerInput;

        public PlayerMoveController(SpaceShip ship, PlayerInput playerInput)
        {
            _ship = ship;
            _playerInput = playerInput;
        }

        public void Update()
        {
            Vector2 moveDirection = new Vector2(_playerInput.MoveDirection, 0f) * Time.fixedDeltaTime;
            _ship.Move(moveDirection);
        }
    }
}