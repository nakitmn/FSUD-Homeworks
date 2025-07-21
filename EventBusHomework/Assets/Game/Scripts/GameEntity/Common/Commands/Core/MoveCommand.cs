namespace SampleGame
{
    public struct MoveCommand : ICommand
    {
        private readonly IGameEntity _source;
        private readonly GameBoardPosition _position;

        public MoveCommand(IGameEntity source,  GameBoardPosition position)
        {
            _source = source;
            _position = position;
        }

        public bool Execute(IGameContext gameContext)
        {
            if (GameBoardMoveUseCase.Move(gameContext, _source, _position))
            {
                var gameBoardView = gameContext.GetGameBoardView();
                var gameBoard = gameContext.GetGameBoard();
                var animationQueue = gameContext.GetAnimationQueue();
                gameBoard.TryGetPosition(_source, out var entityPosition);
                var worldPosition = gameBoardView.ToWorldPosition(entityPosition);
                var moveAnimationCommand = new MoveAnimationCommand(_source.GetTransform(), worldPosition);
                animationQueue.Enqueue(moveAnimationCommand);
                return true;
            }

            return false;
        }
    }
}