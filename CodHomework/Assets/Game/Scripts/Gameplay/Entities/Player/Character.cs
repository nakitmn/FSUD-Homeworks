using Modules.Entity;
using Modules.Health;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class Character : MonoEntity
    {
        [SerializeField] private Transform _flipTransform;
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _jumpForce;
        [SerializeField] private float _jumpCooldown;
        [SerializeField] private int _maxHealth;
        
        public override void InstallBindings()
        {
            Container.Bind<Rigidbody2D>()
                .FromComponentInHierarchy()
                .AsSingle();
            
            Container.BindInterfacesAndSelfTo<MoveComponent>()
                .AsSingle()
                .WithArguments(_moveSpeed)
                .NonLazy();
            
            Container.BindInterfacesAndSelfTo<FaceComponent>()
                .AsSingle()
                .WithArguments(_flipTransform)
                .NonLazy();
            
            Container.BindInterfacesAndSelfTo<JumpComponent>()
                .AsSingle()
                .WithArguments(_jumpForce)
                .NonLazy();
            
            Container.BindInterfacesAndSelfTo<GroundedCheckComponent>()
                .AsSingle()
                .NonLazy();
            
            Container.Bind<Health>()
                .FromMethod(() => new Health(_maxHealth))
                .AsSingle()
                .NonLazy();
        }

        public override void Start()
        {
            var healthComponent = Get<Health>();
            healthComponent.OnDied += () => gameObject.SetActive(false);
            
            var jumpComponent = Get<JumpComponent>();
            var reloadComponent = new ReloadComponent(_jumpCooldown);
            jumpComponent.AddCondition(() => healthComponent.IsAlive);
            jumpComponent.AddCondition(Get<GroundedCheckComponent>().IsGrounded);
            jumpComponent.AddCondition(reloadComponent.IsReady);
            jumpComponent.OnJump += reloadComponent.Reload;
            
            var moveComponent = Get<MoveComponent>();
            moveComponent.AddCondition(() => healthComponent.IsAlive);
            
            var faceComponent = Get<FaceComponent>();
            faceComponent.AddCondition(() => healthComponent.IsAlive);
        }
    }
}