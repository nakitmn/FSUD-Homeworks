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

        [Space(10)] [Header("Visual")] [SerializeField]
        private SpriteRenderer _spriteRenderer;

        [SerializeField] private Color _damagedColor;
        [SerializeField] private float _damagedEffectDuration;
        [Header("Sfx")] [SerializeField] private AudioClip _jumpClip;
        [SerializeField] private AudioClip _damagedClip;
        [SerializeField] private AudioClip _pushUpClip;
        [SerializeField] private AudioClip _pushOutClip;

        public override void InstallBindings()
        {
            Container.Bind<Rigidbody2D>()
                .FromComponentInHierarchy()
                .AsSingle();

            Container.Bind<AudioSource>()
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

            Container.BindInterfacesAndSelfTo<DamageEffectComponent>()
                .AsSingle()
                .WithArguments(_spriteRenderer, _damagedColor, _damagedEffectDuration)
                .NonLazy();
        }

        public override void Start()
        {
            var healthComponent = Get<Health>();
            healthComponent.OnDied += () => gameObject.SetActive(false);
            healthComponent.OnDamaged += _ =>
            {
                Get<DamageEffectComponent>().Play();
                Get<AudioSource>().PlayOneShot(_damagedClip);
            };

            var moveComponent = Get<MoveComponent>();
            moveComponent.AddCondition(() => healthComponent.IsAlive);

            var faceComponent = Get<FaceComponent>();
            faceComponent.AddCondition(() => healthComponent.IsAlive);

            var jumpComponent = Get<JumpComponent>();
            jumpComponent.AddCondition(() => healthComponent.IsAlive);
            jumpComponent.AddCondition(Get<GroundedCheckComponent>().IsGrounded);
            jumpComponent.OnJumped += () => Get<AudioSource>().PlayOneShot(_jumpClip);

            var pushOutComponent = Get<PushOutComponent>();
            pushOutComponent.AddCondition(() => healthComponent.IsAlive);
            pushOutComponent.OnPushed += () => Get<AudioSource>().PlayOneShot(_pushOutClip);

            var pushUpComponent = Get<PushUpComponent>();
            pushUpComponent.AddCondition(() => healthComponent.IsAlive);
            pushUpComponent.AddCondition(Get<GroundedCheckComponent>().IsGrounded);
            pushUpComponent.OnPushed += () => Get<AudioSource>().PlayOneShot(_pushUpClip);
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