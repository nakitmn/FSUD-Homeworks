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
            if (CharacterTurnUseCase.CanAttackInTurn(_source) == false)
            {
                return false;
            }

            var gameBoard = gameContext.GetGameBoard();
            if (gameBoard.IsFree(_x, _y))
            {
                return false;
            }

            if (gameBoard.TryGetPosition(_source, out var entityX, out var entityY) == false)
            {
                return false;
            }

            if (entityX == _x && entityY == _y)
            {
                return false;
            }

            var attackRange = _source.GetAttackRange().Value;
            if (GameBoardMoveUseCase.IsPositionInRange(entityX, entityY, _x, _y, attackRange) == false)
            {
                return false;
            }

            var target = gameBoard.Get(_x, _y);

            var attackCommand = new AttackCommand(_source, target);
            attackCommand.Execute(gameContext);
            _source.GetCurrentAttacksCount().Value++;
            gameContext.GetAnimationQueue().Execute();
            return true;
        }
    }
}