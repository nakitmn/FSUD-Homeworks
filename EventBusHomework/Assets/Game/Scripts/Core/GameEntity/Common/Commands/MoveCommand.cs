namespace SampleGame
{
    public struct MoveCommand : ICommand
    {
        private readonly IGameEntity _source;
        private readonly GameBoardPosition _position;

        public MoveCommand(IGameEntity source, GameBoardPosition position)
        {
            _source = source;
            _position = position;
        }

        public bool Execute(IGameContext gameContext)
        {
            if (GameBoardUseCase.Move(gameContext, _source, _position) == false)
            {
                return false;
            }

            gameContext.GetEventBus().InvokeMoved(_source, GameBoardUseCase.GetBoardPosition(gameContext, _source));
            return true;
        }
    }
}