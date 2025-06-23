using System;
using Fusion;

namespace Game
{
    public sealed class DeathComponent : NetworkBehaviour
    {
        public event Action<bool> OnDeadChanged; 
        
        [Networked, OnChangedRender(nameof(InvokeDeadChanged))]
        public bool IsDead { get; set; }
        
        private void InvokeDeadChanged()
        {
            OnDeadChanged?.Invoke(IsDead);
        }
    }
}