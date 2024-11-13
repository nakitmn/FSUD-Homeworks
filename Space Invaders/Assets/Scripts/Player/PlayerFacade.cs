using Bullets;
using Level;
using Player.Controllers;
using Player.Observers;
using Space_Ship;
using UnityEngine;

namespace Player
{
    public class PlayerFacade : MonoBehaviour
    {
        [SerializeField] private ShipConfig _shipConfig;
        [SerializeField] private SpaceShip _ship;
        [SerializeField] private BulletFacade _bulletFacade;
        [SerializeField] private LevelBounds _levelBounds;

        private PlayerInput _playerInput;
        private PlayerMoveController _moveController;
        private PlayerFireController _fireController;
        private PlayerDieObserver _dieObserver;

        private void Awake()
        {
            _ship.Construct(_shipConfig, _bulletFacade);

            _playerInput = new PlayerInput();

            _moveController = new PlayerMoveController(_ship, _playerInput);
            _fireController = new PlayerFireController(_ship, _playerInput);

            _dieObserver = new PlayerDieObserver(_ship);
        }

        private void OnEnable()
        {
            _fireController.Enable();
            _dieObserver.Enable();
        }

        private void OnDisable()
        {
            _fireController.Disable();
            _dieObserver.Disable();
        }

        private void Update()
        {
            _playerInput.Update();
        }

        private void FixedUpdate()
        {
            _moveController.Update();
        }

        private void LateUpdate()
        {
            ClampPlayerInBounds();
        }

        private void ClampPlayerInBounds()
        {
            _ship.Position = _levelBounds.ClampInBounds(_ship.Position);
        }
    }
}