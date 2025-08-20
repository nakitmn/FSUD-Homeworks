namespace Game.Core
{
    public static class WaveUseCase
    {
        public static bool IsLastWaveSpawned(in IGameContext context)
        {
            var currentTurn = context.GetTurn().Value;
            var waves = context.GetWaves();
            var lastWave = waves[^1];
            return currentTurn > lastWave.turn;
        }
        
        public static bool TryGetCurrentWave(IGameContext context, out EnemyWaveConfig currentWaveConfig)
        {
            var currentTurn = context.GetTurn().Value;
            var waves = context.GetWaves();

            foreach (var wave in waves)
            {
                if (wave.turn == currentTurn)
                {
                    currentWaveConfig = wave;
                    return true;
                }
            }

            currentWaveConfig = default;
            return false;
        }
    }
}