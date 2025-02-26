using Modules.Entity;
using Modules.Health;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class Character : MonoEntity
    {
        [SerializeField] private Transform _flipTransform;
        [SerializeField] private float _moveSpeed;
        [Header("Jump")] [SerializeField] private float _jumpForce;
        [SerializeField] private float _jumpCooldown;
        [Header("Health")] [SerializeField] private int _maxHealth;
        [Header("Push Side")] [SerializeField] private float _pushSideForce;
        [SerializeField] private float _pushSideCooldown;
        [Header("Push Up")] [SerializeField] private float _pushUpForce;
        [SerializeField] private float _pushUpCooldown;

        public override void InstallBindings()
        {
            Container.Bind<Rigidbody2D>()
                .FromComponentInHierarchy()
                .AsSingle();

            Container.Bind<EntityScannerComponent>()
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

            Container.BindInterfacesAndSelfTo<GroundedCheckComponent>()
                .AsSingle()
                .NonLazy();

            Container.BindInterfacesAndSelfTo<JumpComponent>()
                .AsSingle()
                .WithArguments(_jumpCooldown, _jumpForce)
                .NonLazy();
            
            Container.BindInterfacesAndSelfTo<PushUpComponent>()
                .AsSingle()
                .WithArguments(_pushUpCooldown, _pushUpForce)
                .NonLazy();
            
            Container.BindInterfacesAndSelfTo<PushOutComponent>()
                .AsSingle()
                .WithArguments(_pushSideCooldown, _pushSideForce)
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

            var moveComponent = Get<MoveComponent>();
            moveComponent.AddCondition(() => healthComponent.IsAlive);

            var faceComponent = Get<FaceComponent>();
            faceComponent.AddCondition(() => healthComponent.IsAlive);

            var jumpComponent = Get<JumpComponent>();
            jumpComponent.AddCondition(() => healthComponent.IsAlive);
            jumpComponent.AddCondition(Get<GroundedCheckComponent>().IsGrounded);

            var pushOutComponent = Get<PushOutComponent>();
            pushOutComponent.AddCondition(() => healthComponent.IsAlive);

            var pushUpComponent = Get<PushUpComponent>();
            pushUpComponent.AddCondition(() => healthComponent.IsAlive);
            pushUpComponent.AddCondition(Get<GroundedCheckComponent>().IsGrounded);
        }

        public void Jump()
        {
            Get<JumpComponent>().Jump();
        }

        public void PushUp()
        {
            var entities = Get<EntityScannerComponent>().ScanMultiple();
            entities.Remove(this);
            Get<PushUpComponent>().Push(entities);
        }

        public void PushSide()
        {
            var entities = Get<EntityScannerComponent>().ScanMultiple();
            entities.Remove(this);
            Get<PushOutComponent>().Push(entities);
        }
    }
}