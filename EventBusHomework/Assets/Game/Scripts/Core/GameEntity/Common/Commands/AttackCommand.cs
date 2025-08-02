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
            var dealDamageCommand = new DealDamageCommand(_target, _source.GetDamage());
            if (dealDamageCommand.Execute(gameContext))
            {
                var gameBoard = gameContext.GetGameBoard();
                gameBoard.TryGetPosition(_source, out var sourcePosition);
                gameBoard.TryGetPosition(_target, out var targetPosition);
                var pushDirection = (targetPosition - sourcePosition).ToVector2Int();
                var pushCommand = new PushCommand(_target, pushDirection);
                pushCommand.Execute(gameContext);
                return true;
            }

            return false;
        }
    }
}