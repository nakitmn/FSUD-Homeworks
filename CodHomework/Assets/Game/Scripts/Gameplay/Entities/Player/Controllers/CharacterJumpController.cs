using Zenject;

namespace Game.Gameplay
{
    public sealed class CharacterJumpController : ITickable
    {
        private readonly Character _character;
        private readonly PlayerInput _playerInput;

        public CharacterJumpController(Character character, PlayerInput playerInput)
        {
            _character = character;
            _playerInput = playerInput;
        }

        void ITickable.Tick()
        {
            if (_playerInput.IsJump)
            {
                _character.Jump();
            }
        }
    }
}