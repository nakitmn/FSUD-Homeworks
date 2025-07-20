using UnityEngine;

namespace SampleGame
{
    public struct PushCommand : ICommand
    {
        private readonly IGameEntity _target;
        private readonly Vector2Int _direction;

        public PushCommand(IGameEntity target, Vector2Int direction)
        {
            _target = target;
            _direction = direction;
        }

        public bool Execute(IGameContext gameContext)
        {
            var gameBoard = gameContext.GetGameBoard();
            if (gameBoard.TryGetPosition(_target, out var x, out var y) == false)
            {
                return false;
            }

            var newPosition = new Vector2Int()
            {
                x = x + _direction.x,
                y = y + _direction.y,
            };

            if (gameBoard.IsInBounds(newPosition.x, newPosition.y) == false)
            {
                return false;
            }

            if (gameBoard.IsFree(newPosition.x, newPosition.y) == false)
            {
                var entity = gameBoard.Get(newPosition.x, newPosition.y);
                var dealDamageCommand = new DealDamageCommand(entity, 1);
                dealDamageCommand.Execute(gameContext);
                return new PushCommand(entity, _direction).Execute(gameContext);
            }

            var moveCommand = new MoveCommand(_target, newPosition.x, newPosition.y);
            return moveCommand.Execute(gameContext);
        }
    }
}