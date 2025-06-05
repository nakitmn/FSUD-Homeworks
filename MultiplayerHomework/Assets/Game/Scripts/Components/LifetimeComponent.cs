using Fusion;
using UnityEngine;

namespace Game
{
    public sealed class LifetimeComponent : NetworkBehaviour
    {
        [SerializeField] private float _lifetime;

        [Networked] private TickTimer Timer { get; set; }

        public override void Spawned()
        {
            Timer = TickTimer.CreateFromSeconds(Runner, _lifetime);
        }

        public override void FixedUpdateNetwork()
        {
            if (Timer.Expired(Runner))
            {
                Runner.Despawn(Object);
            }
        }
    }
}