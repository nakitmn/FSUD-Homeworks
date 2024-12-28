using Coins_Module;
using Modules;

namespace Snake_Module
{
    public sealed class SnakeExpandController : ICoinCollectedListener
    {
        private readonly ISnake _snake;

        public SnakeExpandController(ISnake snake)
        {
            _snake = snake;
        }

        public void OnCollected(ICoin coin)
        {
            _snake.Expand(coin.Bones);
        }
    }
}