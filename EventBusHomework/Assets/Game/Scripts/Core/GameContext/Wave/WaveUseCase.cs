namespace SampleGame
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
        
        public static bool TryGetCurrentWave(IGameContext context, out SpawnWave currentWave)
        {
            var currentTurn = context.GetTurn().Value;
            var waves = context.GetWaves();

            foreach (var wave in waves)
            {
                if (wave.turn == currentTurn)
                {
                    currentWave = wave;
                    return true;
                }
            }

            currentWave = default;
            return false;
        }
    }
}