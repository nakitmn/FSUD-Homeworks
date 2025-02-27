using Modules.Entity;
using Modules.Health;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class Snake : MonoEntity
    {
        [Header("Movement")]  
        [SerializeField] private Transform _flipTransform;
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _stoppingDistance = 0.1f;
        
        [Header("Health")]  
        [SerializeField] private int _maxHealth = 3;
        
        [Header("Attack")] 
        [SerializeField] private int _damage;
        [SerializeField] private float _pushCooldown;
        [SerializeField] private float _pushForce;
        
        [Space(10)]
        [Header("Visual")]  
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Color _damagedColor;
        [SerializeField] private float _damagedEffectDuration;
        
        public override void InstallBindings()
        {
            Container.Bind<Rigidbody2D>()
                .FromComponentInHierarchy()
                .AsSingle()
                .NonLazy();
            
            Container.Bind<AudioSource>()
                .FromComponentInHierarchy()
                .AsSingle();

            Container.Bind<TriggerEntityDetectorComponent>()
                .FromComponentInHierarchy()
                .AsSingle()
                .NonLazy();

            Container.Bind<PatrolPointsComponent>()
                .FromComponentInHierarchy()
                .AsSingle()
                .NonLazy();

            Container.Bind<Health>()
                .FromMethod(() => new Health(_maxHealth))
                .AsSingle()
                .NonLazy();
            
            Container.Bind<TakeDamageComponent>()
                .AsSingle()
                .NonLazy();

            Container.BindInterfacesAndSelfTo<PushUpComponent>()
                .AsSingle()
                .WithArguments(_pushCooldown, _pushForce)
                .NonLazy();
            
            Container.BindInterfacesAndSelfTo<MoveComponent>()
                .AsSingle()
                .WithArguments(_moveSpeed)
                .NonLazy();
            
            Container.BindInterfacesAndSelfTo<FaceComponent>()
                .AsSingle()
                .WithArguments(_flipTransform)
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
                Get<AudioSource>().Play();
            };
            
            Get<TriggerEntityDetectorComponent>().OnDetected += entity =>
            {
                if (entity.TryGet<TakeDamageComponent>(out var takeDamageComponent))
                {
                    takeDamageComponent.Damage(_damage);
                    Get<PushUpComponent>().Push(entity);
                }
            };
        }

        private void Update()
        {
            var patrolPointsComponent = Get<PatrolPointsComponent>();
            var currentPoint = patrolPointsComponent.Current;
            var distanceDirection = currentPoint.position - transform.position;
            distanceDirection.y = 0;

            if (Mathf.Abs(distanceDirection.x) > _stoppingDistance)
            {
                distanceDirection.x = Mathf.Sign(distanceDirection.x);
                Get<MoveComponent>().SetDirection(distanceDirection.normalized);
                Get<FaceComponent>().SetDirection(Mathf.Sign(distanceDirection.x));
            }
            else
            {
                patrolPointsComponent.Next();
            }
        }
    }
}