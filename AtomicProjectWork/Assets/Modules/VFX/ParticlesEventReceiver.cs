using System;
using UnityEngine;

namespace SampleGame
{
    [RequireComponent(typeof(ParticleSystem))]
    public sealed class ParticlesEventReceiver : MonoBehaviour
    {
        public event Action OnStopped;
        
        private void OnParticleSystemStopped()
        {
            OnStopped?.Invoke();
        }
    }
}