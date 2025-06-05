using Fusion;
using UnityEngine;

namespace Game
{
    [CreateAssetMenu(
        fileName = "BulletConfig",
        menuName = "Game/Projectiles/New BulletConfig"
    )]
    public sealed class BulletConfig : ProjectileConfig
    {
        [SerializeField] private int _damage = 1;

        [SerializeField] private float _speed = 5;

        [SerializeField] private float _lifetime = 3;

        [SerializeField] private LayerMask _layerMask;

        [SerializeField] private QueryTriggerInteraction _triggerInteraction;

        public override bool SimulateStep(in ProjectileState projectile, in NetworkRunner runner, in PlayerRef player)
        {
            if (this.IsExpired(in projectile, in runner))
                return false;

            Vector3 previousPosition = this.GetPosition(in projectile, runner, runner.Tick - 1);
            Vector3 currentPositon = this.GetPosition(in projectile, runner, runner.Tick);
            Vector3 distance = currentPositon - previousPosition;

            PhysicsScene physicsScene = runner.GetPhysicsScene();
            if (!physicsScene.Raycast(previousPosition, distance.normalized, out RaycastHit hit, distance.magnitude,
                    _layerMask, _triggerInteraction))
                return true;

            if (!this.DealDamage(in hit, in player))
                return true;

            return false;
        }

        private bool IsExpired(in ProjectileState projectile, in NetworkRunner runner)
        {
            int lifetime = Mathf.Max(1, (int) (_lifetime / runner.DeltaTime));
            return projectile.tick + lifetime < runner.Tick;
        }

        private Vector3 GetPosition(in ProjectileState projectile, in NetworkRunner runner, in Tick tick)
        {
            float time = (tick - projectile.tick) * runner.DeltaTime;
            return this.GetPosition(projectile, time);
        }

        public override Vector3 GetPosition(in ProjectileState projectile, in float time)
        {
            if (time <= 0)
                return projectile.position;

            Vector3 direction = projectile.rotation * Vector3.forward;
            return projectile.position + direction * (_speed * time);
        }

        public override Quaternion GetRotation(in ProjectileState projectile, in float time)
        {
            return projectile.rotation;
        }

        private bool DealDamage(in RaycastHit hit, in PlayerRef player)
        {
            Collider collider = hit.collider;

            NetworkObject other = collider.GetComponent<NetworkObject>();
            if (player.IsNone == false && other.InputAuthority == player)
            {
                return false;
            }

            HealthComponent healthComponent = other.GetComponent<HealthComponent>();
            return healthComponent.TakeDamage(_damage);
        }

        public override void DrawGizmos(in ProjectileState projectile, in NetworkRunner runner, in PlayerRef player)
        {
            Color prevColor = Gizmos.color;
            Gizmos.color = player == runner.LocalPlayer ? Color.blue : Color.red;

            Vector3 position = this.GetPosition(projectile, runner, runner.Tick);
            Gizmos.DrawSphere(position, radius: 0.125f);
            Gizmos.color = prevColor;
        }
    }
}