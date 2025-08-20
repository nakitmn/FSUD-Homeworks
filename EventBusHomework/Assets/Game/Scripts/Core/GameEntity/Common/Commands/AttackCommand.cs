namespace Game.Core
{
    public readonly struct AttackEventData
    {
        public readonly IGameEntity Source;
        public readonly IGameEntity Target;
        public readonly GameBoardPosition SourcePosition;
        public readonly GameBoardPosition TargetPosition;

        public AttackEventData(IGameEntity source, IGameEntity target, GameBoardPosition sourcePosition,
            GameBoardPosition targetPosition)
        {
            Source = source;
            Target = target;
            SourcePosition = sourcePosition;
            TargetPosition = targetPosition;
        }
    }

    public readonly struct AttackCommand : ICommand
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
            var gameBoard = gameContext.GetGameBoard();
            gameBoard.TryGetPosition(_source, out var sourcePosition);
            gameBoard.TryGetPosition(_target, out var targetPosition);

            gameContext.GetEventBus().InvokeAttackStarted(
                new AttackEventData(
                    _source,
                    _target,
                    sourcePosition,
                    targetPosition
                )
            );

            if (HealthUseCase.DealDamage(_target, _source.GetDamage()) == false)
            {
                gameContext.GetEventBus().InvokeAttackEnded(
                    new AttackEventData(
                        _source,
                        _target,
                        sourcePosition,
                        targetPosition
                    )
                );
                
                return false;
            }

            if (HealthUseCase.Exists(_target) == false)
            {
                gameBoard[targetPosition] = null;
                gameContext.GetEventBus().InvokeDied(_target);
                
                gameContext.GetEventBus().InvokeAttackEnded(
                    new AttackEventData(
                        _source,
                        _target,
                        sourcePosition,
                        targetPosition
                    )
                );
                
                return true;
            }
            
            var pushDirection = (targetPosition - sourcePosition).ToVector2Int();
            var pushCommand = new PushCommand(_target, pushDirection);
            pushCommand.Execute(gameContext);
            
            gameContext.GetEventBus().InvokeAttackEnded(
                new AttackEventData(
                    _source,
                    _target,
                    sourcePosition,
                    targetPosition
                )
            );
            
            return true;
        }
    }
}