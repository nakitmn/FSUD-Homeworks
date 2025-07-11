using Atomic.Entities;
using Atomic.Extensions;

namespace SampleGame
{
    public abstract class ScriptableEntityAspect<T> : ScriptableEntityAspect where T : IEntity
    {
        public override void Apply(IEntity entity)
        {
            Apply((T)entity);
        }

        public override void Discard(IEntity entity)
        {
            Discard((T)entity);
        }

        public abstract void Apply(T entity);
        public abstract void Discard(T entity);
    }
}