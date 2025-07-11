using System;
using Atomic.Entities;
using UnityEngine;

namespace SampleGame
{
    public abstract class Effect : IBehaviour, IDisposable
    {
        public string Name => _config.Name;
        public string Description => _config.Description;
        public Sprite Icon => _config.Icon;

        private readonly EffectConfig _config;
        protected readonly IGameEntity _target;

        protected Effect(in EffectConfig config, in IGameEntity target)
        {
            _config = config;
            _target = target;
            _target.AddBehaviour(this);
        }
        
        public void Dispose()
        {
            _target.DelBehaviour(this);
            this.OnDispose();
        }

        protected abstract void OnDispose();
    }
}