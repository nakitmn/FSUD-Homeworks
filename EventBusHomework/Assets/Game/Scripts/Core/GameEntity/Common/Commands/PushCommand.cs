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
                gameBoard[position] = null;
                HealthUseCase.Kill(_target);
                gameContext.GetEventBus().InvokePushedOut(_target, position, _direction);

                // TODO: Move to animation command
                /*var animationQueue = gameContext.GetAnimationQueue();
                var worldPosition = GameBoardUseCase.GetWorldPosition(gameContext, newPosition);
                worldPosition.y -= 2f;
                var dieAnimationCommand = new DieFromBoundsAnimationCommand(_target.GetTransform(), worldPosition);
                animationQueue.Enqueue(dieAnimationCommand);*/

                return false;
            }

            if (gameBoard.IsFree(newPosition) == false)
            {
                var entity = gameBoard[newPosition];
                gameContext.GetEventBus().InvokePushedInTarget(_target, entity);
                HealthUseCase.DealDamage(entity, 1);
                if (HealthUseCase.Exists(entity))
                {
                    return new PushCommand(entity, _direction).Execute(gameContext);
                }
                
                gameContext.GetEventBus().InvokeDied(_target);
                return false;
            }

            if (GameBoardUseCase.Move(gameContext, _target, newPosition))
            {
                gameContext.GetEventBus().InvokePushed(_target, position, _direction);
                return true;
            }

            return false;
        }
    }
}