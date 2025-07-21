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
                gameBoard.TryGetPosition(_source, out var sourceX, out var sourceY);
                gameBoard.TryGetPosition(_target, out var targetX, out var targetY);
                var pushDirection = new Vector2Int()
                {
                    x = targetX - sourceX,
                    y = targetY - sourceY,
                };
                var pushCommand = new PushCommand(_target, pushDirection);
                pushCommand.Execute(gameContext);
                return true;
            }

            return false;
        }
    }
}