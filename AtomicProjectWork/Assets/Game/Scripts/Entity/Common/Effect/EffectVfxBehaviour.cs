using System.Collections.Generic;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace SampleGame
{
    public sealed class EffectVfxBehaviour : IInit, IDispose
    {
        private readonly Dictionary<string, ParticleSystem> _vfxs;
        private IReactiveDictionary<string, EffectInstance> _effects;

        public EffectVfxBehaviour(Dictionary<string, ParticleSystem> vfxs)
        {
            _vfxs = vfxs;
        }

        public void Init(in IEntity entity)
        {
            _effects = entity.GetEffects();
            _effects.OnItemAdded += this.OnEffectAdded;
            _effects.OnItemRemoved += this.OnEffectRemoved;

            this.StartVfx();
        }

        public void Dispose(in IEntity entity)
        {
            _effects.OnItemAdded -= this.OnEffectAdded;
            _effects.OnItemRemoved -= this.OnEffectRemoved;
            
            this.StopVfx();
        }

        private void OnEffectAdded(string key, EffectInstance value) => _vfxs[key].Play();

        private void OnEffectRemoved(string key, EffectInstance value) => _vfxs[key].Stop();

        private void StartVfx()
        {
            foreach (var (key, value) in _effects)
            {
                _vfxs[key].Play();
            }
        }
        
        private void StopVfx()
        {
            foreach (ParticleSystem vfx in _vfxs.Values) 
                vfx.Stop();
        }
    }
}