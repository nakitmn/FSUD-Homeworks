using Fusion;
using UnityEngine;

namespace Game
{
    public sealed class InstantFireComponent : FireComponent
    {
        [SerializeField] private ProjectileType _projectileType;
        [SerializeField] private ProjectileWorld _projectileWorld;
        [SerializeField] private Transform _firePoint;
        [SerializeField] private float _cooldown;
        
        [Networked] private TickTimer CooldownTimer { get; set; }

        public override void Fire()
        {
            if (CooldownTimer.ExpiredOrNotRunning(Runner))
            {
                _projectileWorld.Spawn(_projectileType,_firePoint.position,_firePoint.rotation);
                CooldownTimer = TickTimer.CreateFromSeconds(Runner, _cooldown);
            }
        }       
    }
}

/*[SerializeField] private Transform _firePoint;
[SerializeField] private float _cooldown;
[SerializeField] private int _damage;

private readonly RaycastHit[] _hits = new RaycastHit[8];

[Networked] private TickTimer CooldownTimer { get; set; }

public void Fire()
{
    if (CooldownTimer.ExpiredOrNotRunning(Runner))
    {
        var physicsScene = Runner.GetPhysicsScene();
        var count = physicsScene.Raycast(_firePoint.position, _firePoint.forward,
            _hits, layerMask: Physics.AllLayers);

        for (var i = 0; i < count; i++)
        {
            var hit = _hits[i];
            var healthComponent = hit.collider.GetComponent<HealthComponent>();
            if (healthComponent != null)
            {
                healthComponent.TakeDamage(_damage);
            }
        }

        CooldownTimer = TickTimer.CreateFromSeconds(Runner, _cooldown);
    }
} */  