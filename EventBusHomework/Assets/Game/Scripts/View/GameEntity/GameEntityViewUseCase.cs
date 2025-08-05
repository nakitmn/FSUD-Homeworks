using Atomic.Entities;
using SampleGame;

namespace Game.View
{
    public static class GameEntityViewUseCase
    {
        public static EntityView GetView(IViewContext viewContext, IGameEntity entity)
        {
            return viewContext.GetWorldView().GetView(entity);
        }
    }
}