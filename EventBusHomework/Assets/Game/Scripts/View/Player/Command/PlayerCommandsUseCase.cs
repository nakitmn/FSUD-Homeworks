using Game.View;

namespace SampleGame
{
    public static class PlayerCommandsUseCase
    {
        public static void ExecuteWithVisual(IGameContext gameContext,IViewContext viewContext, ICommand command)
        {
            command.Execute(gameContext);
            viewContext.GetAnimationQueue().Execute().Forget();
        }
    }
}