namespace SampleGame
{
    public static class EnemySpawnUseCase
    {
        public static bool TrySpawnEnemies(IGameContext context)
        {
            if (WaveUseCase.TryGetCurrentWave(context, out var wave) == false)
            {
                return false;
            }

            var gameBoard = context.GetGameBoard();
            var spawnPoints = wave.points;

            foreach (var position in spawnPoints)
            {
                if (gameBoard.IsFree(position) == false)
                {
                    var entity = gameBoard[position];
                    var dealDamageCommand = new DealDamageCommand(entity, 1);
                    dealDamageCommand.Execute(context);
                }
                else
                {
                    SpawnEntityUseCase.Spawn(context, wave.prefab, position);
                }
            }

            return true;
        }
    }
}