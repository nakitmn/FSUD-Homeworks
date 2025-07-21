namespace SampleGame
{
    public struct CharacterMoveCommand : ICommand
    {
        private readonly IGameEntity _source;
        private readonly int _x;
        private readonly int _y;

        public CharacterMoveCommand(IGameEntity source, int x, int y)
        {
            _source = source;
            _x = x;
            _y = y;
        }

        public bool Execute(IGameContext gameContext)
        {
            if (CharacterTurnUseCase.CanMoveInTurn(_source) == false)
            {
                return false;
            }
            
            var moveCommand = new MoveCommand(_source,_x, _y);
            if (moveCommand.Execute(gameContext))
            {
                _source.GetCurrentMovesCount().Value++;
                gameContext.GetAnimationQueue().Execute();
                return true;
            }
            
            return false;
        }
    }
}