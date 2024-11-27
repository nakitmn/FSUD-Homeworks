using Input_Module;
using Modules;
using Zenject;

namespace DefaultNamespace
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
            var direction = _playerInput.Direction;
            
            if (direction.x < 0f)
            {
                _snake.Turn(SnakeDirection.LEFT);
            }
            else if (direction.x > 0f)
            {
                _snake.Turn(SnakeDirection.RIGHT);
            }
            else if (direction.y < 0f)
            {
                _snake.Turn(SnakeDirection.DOWN);
            }
            else if (direction.y > 0f)
            {
                _snake.Turn(SnakeDirection.UP);
            }
            else
            {
                _snake.Turn(SnakeDirection.NONE);
            }
        }
    }
}