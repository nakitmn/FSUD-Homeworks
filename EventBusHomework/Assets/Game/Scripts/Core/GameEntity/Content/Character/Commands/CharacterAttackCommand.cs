namespace SampleGame
{
    public struct CharacterAttackCommand : ICommand
    {
        private readonly IGameEntity _source;
        private readonly GameBoardPosition _position;

        public CharacterAttackCommand(IGameEntity source, GameBoardPosition position)
        {
            _source = source;
            _position = position;
        }

        public bool Execute(IGameContext gameContext)
        {
            if (CharacterTurnUseCase.CanAttackInTurn(_source) == false)
            {
                return false;
            }

            var gameBoard = gameContext.GetGameBoard();
            if (gameBoard.IsFree(_position))
            {
                return false;
            }

            if (gameBoard.TryGetPosition(_source, out var entityPosition) == false)
            {
                return false;
            }

            if (entityPosition == _position)
            {
                return false;
            }

            var attackRange = _source.GetAttackRange().Value;
            if (GameBoardPosition.IsPositionInRange(entityPosition, _position, attackRange) == false)
            {
                return false;
            }

            var target = gameBoard[_position];
            var attackCommand = new AttackCommand(_source, target);
            attackCommand.Execute(gameContext);
            _source.GetCurrentAttacksCount().Value++;
            return true;
        }
    }
}