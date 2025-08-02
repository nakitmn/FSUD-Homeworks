using Atomic.Entities;

namespace Game.View
{
    public interface IViewContext : IEntity
    {
        
    }
    public sealed class ViewContext : SceneEntitySingleton<ViewContext>, IViewContext
    {
        
    }
}