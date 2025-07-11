using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace SampleGame
{
    public sealed class EventVfxBehaviour : IInit, IDispose
    {
        private readonly IEvent _vfxEvent;
        private readonly ParticleSystem _effect;

        public EventVfxBehaviour(IEvent vfxEvent, ParticleSystem effect)
        {
            _vfxEvent = vfxEvent;
            _effect = effect;
        }

        public void Init(in IEntity entity)
        {
            _vfxEvent.Subscribe(_effect.Play);
        }

        public void Dispose(in IEntity entity)
        {
            _vfxEvent.Unsubscribe(_effect.Play);
        }
    }
}