using Zenject;

namespace Game.Gameplay
{
    public sealed class CharacterMoveController : ITickable
    {
        private readonly Character _character;
        private readonly PlayerInput _playerInput;

        public CharacterMoveController(Character character, PlayerInput playerInput)
        {
            _character = character;
            _playerInput = playerInput;
        }

        void ITickable.Tick()
        {
            var moveComponent = _character.Get<MoveComponent>();
            var faceComponent = _character.Get<FaceComponent>();
            
            moveComponent.SetDirection(_playerInput.MoveDirection);
            faceComponent.SetDirection(_playerInput.HorizontalDirection);
        }
    }
}