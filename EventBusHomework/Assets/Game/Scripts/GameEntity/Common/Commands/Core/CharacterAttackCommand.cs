using UnityEngine;

namespace SampleGame
{
    public struct CharacterAttackCommand : ICommand
    {
        private readonly IGameEntity _source;
        private readonly int _x;
        private readonly int _y;

        public CharacterAttackCommand(IGameEntity source, int x, int y)
        {
            _source = source;
            _x = x;
            _y = y;
        }

        public bool Execute(IGameContext gameContext)
        {
            var gameBoard = gameContext.GetGameBoard();
            if (gameBoard.IsFree(_x, _y))
            {
                return false;
            }

            if (gameBoard.TryGetPosition(_source, out var entityX, out var entityY) == false)
            {
                return false;
            }

            var attackRange = _source.GetAttackRange().Value;

            var distanceX = Mathf.Abs(entityX) - Mathf.Abs(_x);
            var distanceY = Mathf.Abs(entityY) - Mathf.Abs(_y);
            if (Mathf.Abs(distanceX) > attackRange || Mathf.Abs(distanceY) > attackRange)
            {
                return false;
            }

            var target = gameBoard.Get(_x, _y);

            var dealDamageCommand = new DealDamageCommand(_source, target);
            if (dealDamageCommand.Execute(gameContext))
            {
                var dealDamageAnimationCommand = new DealDamageAnimationCommand(target.GetTransform());
                dealDamageAnimationCommand.Execute();
                return true;
            }
            
            return false;
        }
    }
}