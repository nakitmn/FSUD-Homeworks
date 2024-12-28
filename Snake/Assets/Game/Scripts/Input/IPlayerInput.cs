using Modules;

namespace Game.Gameplay
{
    public interface IPlayerInput
    {
        SnakeDirection Direction { get; }
    }
}