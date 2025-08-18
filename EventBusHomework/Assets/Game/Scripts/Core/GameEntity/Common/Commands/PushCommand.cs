using UnityEngine;

namespace SampleGame
{
    public readonly struct PushInTargetEventData
    {
        public readonly IGameEntity Source;
        public readonly IGameEntity Target;
        public readonly GameBoardPosition SourcePosition;
        public readonly GameBoardPosition TargetPosition;
        public readonly Vector2Int PushPosition;

        public PushInTargetEventData(IGameEntity source, IGameEntity target, GameBoardPosition sourcePosition,
            GameBoardPosition targetPosition, Vector2Int pushPosition)
        {
            Source = source;
            Target = target;
            SourcePosition = sourcePosition;
            TargetPosition = targetPosition;
            PushPosition = pushPosition;
        }
    }

    public readonly struct PushCommand : ICommand
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
                return false;
            }

            if (gameBoard.IsFree(newPosition) == false)
            {
                var entity = gameBoard[newPosition];
                gameContext.GetEventBus().InvokePushedInTarget(
                    new PushInTargetEventData(
                        _target,
                        entity,
                        position,
                        newPosition,
                        _direction
                    )
                );
                HealthUseCase.DealDamage(entity, 1);
                if (HealthUseCase.Exists(entity))
                {
                    return new PushCommand(entity, _direction).Execute(gameContext);
                }

                gameBoard[newPosition] = null;
                gameContext.GetEventBus().InvokeDied(entity);
                return false;
            }

            if (gameBoard.Move(_target, newPosition))
            {
                gameContext.GetEventBus().InvokePushed(_target, position, _direction);
                return true;
            }

            return false;
        }
    }
}