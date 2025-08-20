using Atomic.Entities;

namespace Game.Core
{
    public interface IGameContext : IEntity
    {
        
    }
    
    public sealed class GameContext : EntitySingleton<GameContext>, IGameContext
    {
        
    }
}