using Atomic.Entities;

namespace SampleGame
{
    public sealed class Ability : Entity
    {
        public Ability(in string name) : base(in name)
        {
        }
    }
}