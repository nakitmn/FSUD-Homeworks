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
            if (GameBoardMoveUseCase.Move(gameContext, _source, _x, _y))
            {
                var gameBoardView = gameContext.GetGameBoardView();
                var gameBoard = gameContext.GetGameBoard();
                var animationQueue = gameContext.GetAnimationQueue();
                gameBoard.TryGetPosition(_source, out var entityX, out var entityY);
                var worldPosition = gameBoardView.ToWorldPosition(entityX, entityY);
                var moveAnimationCommand = new MoveAnimationCommand(_source.GetTransform(), worldPosition);
                animationQueue.Enqueue(moveAnimationCommand);
                return true;
            }

            return false;
        }
    }
}