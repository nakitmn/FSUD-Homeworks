using Atomic.Entities;

namespace SampleGame
{
    public interface IGameEntity : IEntity
    {
    }

    public class GameEntity : SceneEntity, IGameEntity
    {
    }
}