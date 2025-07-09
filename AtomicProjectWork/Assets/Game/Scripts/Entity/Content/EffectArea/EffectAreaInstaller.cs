using Atomic.Elements;
using Atomic.Entities;
using Atomic.Extensions;
using UnityEngine;

namespace SampleGame
{
    public sealed class EffectAreaInstaller : SceneEntityInstaller
    {
        [SerializeField]
        private TriggerEventReceiver _trigger;

        [SerializeField]
        private ScriptableEntityAspect _effect;

        public override void Install(IEntity entity)
        {
            entity.AddTrigger(_trigger);
            entity.AddBehaviour(new EffectAreaBehaviour(_effect));
        }
    }
}