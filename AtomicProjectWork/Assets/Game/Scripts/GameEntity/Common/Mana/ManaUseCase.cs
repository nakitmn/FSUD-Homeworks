using Atomic.Elements;
using Atomic.Entities;

namespace SampleGame
{
    public static class ManaUseCase
    {
        public static bool Enough(in IGameEntity context, in int amount)
        {
            return context.GetCurrentMana().Value >= amount;
        }
        
        public static bool Spend(in IGameEntity context, int amount)
        {
            IReactiveVariable<int> currentMana = context.GetCurrentMana();
            if (currentMana.Value < amount)
                return false;

            currentMana.Value -= amount;
            return true;
        } 
    }
}