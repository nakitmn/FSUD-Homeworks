using Modules;

namespace Coins_Module
{
    public interface ICoinCollectedListener
    {
        void OnCollected(ICoin coin);
    }
}