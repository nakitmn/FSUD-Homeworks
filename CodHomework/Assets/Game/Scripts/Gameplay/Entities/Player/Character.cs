using Modules.Entity;
using Modules.Health;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class Character : MonoEntity
    {
        private static readonly int JumpKey = Animator.StringToHash("Jump");
        
        [Header("Movement")] 
        [SerializeField] private Transform _flipTransform;
        [SerializeField] private float _moveSpeed;
        
        [Header("Jump")] 
        [SerializeField] private float _jumpForce;
        [SerializeField] private float _jumpCooldown;
        
        [Header("Health")] 
        [SerializeField] private int _maxHealth;
        
        [Header("Push Side")] 
        [SerializeField] private float _pushSideForce;
        [SerializeField] private float _pushSideCooldown;
        
        [Header("Push Up")] 
        [SerializeField] private float _pushUpForce;
        [SerializeField] private float _pushUpCooldown;

        [Space(10)] 
        [Header("Visual")] 
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Color _damagedColor;
        [SerializeField] private float _damagedEffectDuration;
        
        [Header("SFX")] 
        [SerializeField] private AudioClip _jumpClip;
        [SerializeField] private AudioClip _damagedClip;
        [SerializeField] private AudioClip _pushUpClip;
        [SerializeField] private AudioClip _pushOutClip;
        
        [Header("VFX")] 
        [SerializeField] private ParticleSystem _pushUpParticle;
        [SerializeField] private ParticleSystem _pushOutParticle;

        public override void InstallBindings()
        {
            Container.Bind<Rigidbody2D>()
                .FromComponentInHierarchy()
                .AsSingle();

            Container.Bind<AudioSource>()
                .FromComponentInHierarchy()
                .AsSingle();
            
            Container.Bind<Animator>()
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
            var audioSource = Get<AudioSource>();
            var groundedCheckComponent = Get<GroundedCheckComponent>();

            var healthComponent = Get<Health>();
            healthComponent.OnDied += () => gameObject.SetActive(false);
            healthComponent.OnDamaged += _ =>
            {
                Get<DamageEffectComponent>().Play();
                audioSource.PlayOneShot(_damagedClip);
            };

            Get<MoveComponent>().AddCondition(() => healthComponent.IsAlive);

            Get<FaceComponent>().AddCondition(() => healthComponent.IsAlive);

            var jumpComponent = Get<JumpComponent>();
            jumpComponent.AddCondition(() => healthComponent.IsAlive);
            jumpComponent.AddCondition(groundedCheckComponent.IsGrounded);
            jumpComponent.OnJumped += () =>
            {
                audioSource.PlayOneShot(_jumpClip);
                Get<Animator>().SetTrigger(JumpKey);
            };

            var pushOutComponent = Get<PushOutComponent>();
            pushOutComponent.AddCondition(() => healthComponent.IsAlive);
            pushOutComponent.OnPushed += () =>
            {
                audioSource.PlayOneShot(_pushOutClip);
                _pushOutParticle.Play();
            };

            var pushUpComponent = Get<PushUpComponent>();
            pushUpComponent.AddCondition(() => healthComponent.IsAlive);
            pushUpComponent.AddCondition(groundedCheckComponent.IsGrounded);
            pushUpComponent.OnPushed += () =>
            {
                audioSource.PlayOneShot(_pushUpClip);
                _pushUpParticle.Play();
            };
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