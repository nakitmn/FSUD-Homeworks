namespace SampleGame
{
    public struct MoveCommand : ICommand
    {
        private readonly IGameEntity _source;
        private readonly int _x;
        private readonly int _y;

        public MoveCommand(IGameEntity source, int x, int y)
        {
            _source = source;
            _x = x;
            _y = y;
        }
        
        public bool Execute(IGameContext gameContext)
        {
            return GameBoardMoveUseCase.Move(gameContext, _source, _x, _y);
        }
    }
}