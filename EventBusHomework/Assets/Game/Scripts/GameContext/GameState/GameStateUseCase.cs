namespace SampleGame
{
    public static class GameStateUseCase
    {
        public static void UpdateCurrentState(in IGameContext context)
        {
            var currentState = context.GetCurrentState();
            
            if (IsLose(context))
            {
                currentState.Value = GameState.Lose;
                return;
            }
            
            if (IsWin(context))
            {
                currentState.Value = GameState.Win;
                return;
            }

            currentState.Value = GameState.Running;
        }

        public static bool IsWin(in IGameContext context)
        {
            return WaveUseCase.IsLastWaveSpawned(context) && EnemyUseCase.HasAliveEnemies(context) == false;
        }

        public static bool IsLose(in IGameContext context)
        {
            return PlayerCharactersUseCase.HasAliveCharacters(context) == false;
        }
    }
}