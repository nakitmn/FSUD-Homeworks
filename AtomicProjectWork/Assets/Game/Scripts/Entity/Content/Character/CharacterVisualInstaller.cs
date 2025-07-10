using System;
using System.Linq;
using Atomic.Entities;
using UnityEngine;

namespace SampleGame
{
    public sealed class CharacterVisualInstaller : SceneEntityInstaller
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private string _moveSpeedKey = "NormalizedSpeed";
        [SerializeField] private string _takeDamageKey = "TakeDamage";
        [SerializeField] private string _deathKey = "Death";
        [SerializeField] private ParticleSystem _damagedVfx;
        [SerializeField] private ParticleSystem _deathVfx;
        [SerializeField] private EffectInfo[] _effects;
        
        public override void Install(IEntity entity)
        {
            var deathHash = Animator.StringToHash(_deathKey);

            entity.AddAnimator(_animator);
            
            entity.AddBehaviour(new EventVfxBehaviour(entity.GetDamagedEvent(), _damagedVfx));
            
            entity.AddBehaviour(new MoveSpeedAnimBehaviour(_moveSpeedKey));
            entity.AddBehaviour(new TakeDamageAnimBehaviour(_takeDamageKey));
            entity.AddBehaviour(new EffectVfxBehaviour(_effects.ToDictionary(it => it.config.Name, it => it.vfx)));
            
            entity.GetDeathEvent().Subscribe(() =>
            {
                _animator.SetTrigger(deathHash);
                _deathVfx.Play();
            });
        }
        
        [Serializable]
        private struct EffectInfo
        {
            public EffectConfig config;
            public ParticleSystem vfx;
        }
    }
}