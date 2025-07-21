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
            if (_direction == Vector2Int.zero)
            {
                return false;
            }
            
            var gameBoard = gameContext.GetGameBoard();
            if (gameBoard.TryGetPosition(_target, out var position) == false)
            {
                return false;
            }

            var newPosition = position + _direction;
            if (gameBoard.IsInBounds(newPosition) == false)
            {
                var animationQueue = gameContext.GetAnimationQueue();
                gameBoard[position] = null;
                var worldPosition = GameBoardMoveUseCase.GetWorldPosition(gameContext, newPosition);
                worldPosition.y -= 2f;
                var dieAnimationCommand = new DieFromBoundsAnimationCommand(_target.GetTransform(), worldPosition);
                animationQueue.Enqueue(dieAnimationCommand);
                return false;
            }

            if (gameBoard.IsFree(newPosition) == false)
            {
                var entity = gameBoard[newPosition];
                var dealDamageCommand = new DealDamageCommand(entity, 1);
                dealDamageCommand.Execute(gameContext);
                return new PushCommand(entity, _direction).Execute(gameContext);
            }

            var moveCommand = new MoveCommand(_target, newPosition);
            return moveCommand.Execute(gameContext);
        }
    }
}