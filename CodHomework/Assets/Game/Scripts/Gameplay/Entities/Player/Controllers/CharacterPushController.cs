using Zenject;

namespace Game.Gameplay
{
    public sealed class CharacterPushController : ITickable
    {
        private readonly Character _character;
        private readonly PlayerInput _playerInput;

        public CharacterPushController(Character character, PlayerInput playerInput)
        {
            _character = character;
            _playerInput = playerInput;
        }

        void ITickable.Tick()
        {
            if (_playerInput.IsPushUp)
            {
                _character.PushUp();
                return;
            }
            
            if (_playerInput.IsPushSide)
            {
                _character.PushSide();
                return;
            }
        }
    }
}