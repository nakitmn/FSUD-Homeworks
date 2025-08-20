using Atomic.Entities;

namespace Game.Core
{
    public interface IGameEntity : IEntity
    {
        
    }
    
    public sealed class GameEntity : Entity, IGameEntity
    {
        public GameEntity(string name) : base(name)
        {
        }
    }
}