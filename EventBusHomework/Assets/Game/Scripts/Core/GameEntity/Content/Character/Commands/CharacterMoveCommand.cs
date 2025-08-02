namespace SampleGame
{
    public struct CharacterMoveCommand : ICommand
    {
        private readonly IGameEntity _source;
        private readonly GameBoardPosition _position;

        public CharacterMoveCommand(IGameEntity source, GameBoardPosition position)
        {
            _source = source;
            _position = position;
        }

        public bool Execute(IGameContext gameContext)
        {
            if (CharacterTurnUseCase.CanMoveInTurn(_source) == false)
            {
                return false;
            }
            
            var moveCommand = new MoveCommand(_source, _position);
            if (moveCommand.Execute(gameContext))
            {
                _source.GetCurrentMovesCount().Value++;
                // TODO: start visual
                // gameContext.GetAnimationQueue().Execute();
                return true;
            }
            
            return false;
        }
    }
}