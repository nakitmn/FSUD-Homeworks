using Atomic.Entities;

namespace SampleGame
{
    public interface IGameContext : IEntity
    {
        
    }
    
    public sealed class GameContext : EntitySingleton<GameContext>, IGameContext
    {
        
    }
}