using UnityEngine;

namespace SampleGame
{
    public struct AttackCommand : ICommand
    {
        private readonly IGameEntity _source;
        private readonly IGameEntity _target;

        public AttackCommand(IGameEntity source, IGameEntity target)
        {
            _source = source;
            _target = target;
        }

        public bool Execute(IGameContext gameContext)
        {
            var sourceTransform = _source.GetTransform();
            var animationQueue = gameContext.GetAnimationQueue();
            
            var sourcePosition = GameBoardMoveUseCase.GetWorldPosition(gameContext, _source);
            var targetPosition = GameBoardMoveUseCase.GetWorldPosition(gameContext, _target);
            
            animationQueue.Enqueue(new MoveAnimationCommand(sourceTransform, targetPosition));
            
            var dealDamageCommand = new DealDamageCommand(_target, _source.GetDamage());
            var isDamageDealed = dealDamageCommand.Execute(gameContext);
            
            animationQueue.Enqueue(new MoveAnimationCommand(sourceTransform, sourcePosition));

            var gameBoard = gameContext.GetGameBoard();
            gameBoard.TryGetPosition(_source, out var sourceX,out var sourceY);
            gameBoard.TryGetPosition(_target, out var targetX,out var targetY);
            var pushDirection = new Vector2Int()
            {
                x = targetX - sourceX,
                y = targetY - sourceY,
            };
            var pushCommand = new PushCommand(_target, pushDirection);
            pushCommand.Execute(gameContext);

            return isDamageDealed;
        }
    }
}