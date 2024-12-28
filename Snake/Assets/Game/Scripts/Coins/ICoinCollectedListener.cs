using Modules;

namespace Game.Gameplay
{
    public interface ICoinCollectedListener
    {
        void OnCollected(ICoin coin);
    }
}