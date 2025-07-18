/*using Atomic.Events;

namespace DefaultNamespace
{
    public static class PlayerCommandUseCase
    {
        public static void ExecuteCommand(ICommand command, IGameContext gameContext)
        {
            gameContext.GetEventBus().InvokePlayerCommandStarted();
            command.Execute(gameContext);
        }
    }
}*/