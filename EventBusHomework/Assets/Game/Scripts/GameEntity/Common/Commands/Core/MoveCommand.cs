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
            if (GameBoardMoveUseCase.Move(gameContext, _source, _position) == false)
            {
                return false;
            }

            var worldPosition = GameBoardMoveUseCase.GetWorldPosition(gameContext, _source);
            var moveAnimationCommand = new MoveAnimationCommand(_source.GetTransform(), worldPosition);
            gameContext.GetAnimationQueue().Enqueue(moveAnimationCommand);
            return true;
        }
    }
}