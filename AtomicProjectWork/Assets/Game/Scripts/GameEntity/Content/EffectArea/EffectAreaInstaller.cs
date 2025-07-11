using Atomic.Elements;
using Atomic.Entities;
using Atomic.Extensions;
using UnityEngine;

namespace SampleGame
{
    public sealed class EffectAreaInstaller : SceneEntityInstaller<IGameEntity>
    {
        [SerializeField]
        private TriggerEventReceiver _trigger;

        [SerializeField]
        private ScriptableEntityAspect _effect;

        protected override void Install(IGameEntity entity)
        {
            entity.AddTrigger(_trigger);
            entity.AddBehaviour(new EffectAreaBehaviour(_effect));
        }
    }
}