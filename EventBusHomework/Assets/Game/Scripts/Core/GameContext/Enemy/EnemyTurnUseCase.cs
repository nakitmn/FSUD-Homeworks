namespace Game.Core
{
    public static class EnemyTurnUseCase
    {
        public static void HandleEnemiesTurn(IGameContext context)
        {
            var gameBoard = context.GetGameBoard();
            var enemies = CharacterTurnUseCase.GetEnemyCharacters(context);

            foreach (IGameEntity enemy in enemies)
            {
                if (HealthUseCase.Exists(enemy) == false)
                {
                    continue;
                }

                EnemyUseCase.SelectRandomTarget(context, enemy);
                var target = enemy.GetTarget().Value;
                if (target == null)
                {
                    continue;
                }

                var path = PathfindingUseCase.FindPathToTarget(context, enemy);
                var targetPosition = gameBoard.GetBoardPosition(target);
                var movePosition = path[0];
                var characterMoveCommand = new CharacterMoveCommand(enemy, movePosition);
                characterMoveCommand.Execute(context);
                var attackCommand = new CharacterAttackCommand(enemy, targetPosition);
                attackCommand.Execute(context);
            }
        }
    }
}