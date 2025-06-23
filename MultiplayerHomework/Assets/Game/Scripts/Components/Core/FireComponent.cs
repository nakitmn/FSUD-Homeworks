using Fusion;
using UnityEngine;

namespace Game
{
    public sealed class FireComponent : NetworkBehaviour
    {
        [SerializeField] private FireAnimator _fireAnimator;
        [SerializeField] private ProjectileType _projectileType;
        [SerializeField] private ProjectileWorld _projectileWorld;
        [SerializeField] private Transform _firePoint;
        [SerializeField] private float _delay;
        [SerializeField] private float _cooldown;

        [Networked] private TickTimer DelayTimer { get; set; }
        [Networked] private TickTimer CooldownTimer { get; set; }
        [Networked, OnChangedRender(nameof(OnFireStateChanged))] private bool IsFire { get; set; }

        public override void FixedUpdateNetwork()
        {
            if (IsFire == false)
            {
                return;
            }
            
            if (DelayTimer.Expired(Runner) == false)
            {
                return;
            }

            _projectileWorld.Spawn(_projectileType, _firePoint.position, _firePoint.rotation);
            CooldownTimer = TickTimer.CreateFromSeconds(Runner, _cooldown);
            IsFire = false;
        }

        public void Fire()
        {
            if (IsFire)
            {
                return;
            }
            
            if (CooldownTimer.ExpiredOrNotRunning(Runner) == false)
            {
                return;
            }

            DelayTimer = TickTimer.CreateFromSeconds(Runner, _delay);
            IsFire = true;
        }

        private void OnFireStateChanged()
        {
            if (IsFire)
            {
                _fireAnimator.PlayFire();
            }
        }
    }
}