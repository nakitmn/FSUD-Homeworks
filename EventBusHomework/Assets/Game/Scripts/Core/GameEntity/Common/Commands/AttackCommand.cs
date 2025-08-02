namespace SampleGame
{
    public struct AttackCommand : ICommand
    {
        private readonly IGameEntity _source;
        private readonly IGameEntity _target;

        public AttackCommand(IGameEntity source, IGameEntity target)
        {
            _source = source;
            _target = target;
        }

        public bool Execute(IGameContext gameContext)
        {
            gameContext.GetEventBus().InvokeAttack(_target, _source);
            
            if (HealthUseCase.DealDamage(_target, _source.GetDamage()) == false)
            {
                return false;
            }

            if (HealthUseCase.Exists(_target) == false)
            {
                gameContext.GetEventBus().InvokeDied(_target);
                return true;
            }

            var gameBoard = gameContext.GetGameBoard();
            gameBoard.TryGetPosition(_source, out var sourcePosition);
            gameBoard.TryGetPosition(_target, out var targetPosition);
            var pushDirection = (targetPosition - sourcePosition).ToVector2Int();
            var pushCommand = new PushCommand(_target, pushDirection);
            pushCommand.Execute(gameContext);
            return true;
        }
    }
}