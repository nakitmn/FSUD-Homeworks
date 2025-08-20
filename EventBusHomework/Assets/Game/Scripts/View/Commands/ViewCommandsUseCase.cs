using Game.Core;

namespace Game.View
{
    public static class ViewCommandsUseCase
    {
        public static void ExecuteWithVisual(IGameContext gameContext,IViewContext viewContext, ICommand command)
        {
            command.Execute(gameContext);
            viewContext.GetAnimationQueue().Execute().Forget();
        }
        
        public static void Enqueue(IViewContext viewContext, IAnimationCommand command)
        {
            viewContext.GetAnimationQueue().Enqueue(command);
        }
    }
}