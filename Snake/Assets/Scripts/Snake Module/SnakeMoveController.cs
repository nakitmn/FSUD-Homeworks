using Input_Module;
using Modules;
using Zenject;

namespace Snake_Module
{
    public sealed class SnakeMoveController : ITickable
    {
        private readonly ISnake _snake;
        private readonly IPlayerInput _playerInput;

        public SnakeMoveController(ISnake snake, IPlayerInput playerInput)
        {
            _snake = snake;
            _playerInput = playerInput;
        }

        void ITickable.Tick()
        {
            _snake.Turn(_playerInput.Direction);
        }
    }
}