using Modules.Entity;
using Modules.Health;
using UnityEngine;

namespace Game.Gameplay.Entities.Spider
{
    public sealed class Spider : MonoEntity
    {
        [SerializeField] private int _maxHealth = 3;
        [SerializeField] private int _damage;
        [SerializeField] private float _pushCooldown;
        [SerializeField] private float _pushForce;
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _stoppingDistance = 0.1f;

        public override void InstallBindings()
        {
            Container.Bind<Rigidbody2D>()
                .FromComponentInHierarchy()
                .AsSingle()
                .NonLazy();

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

            Container.BindInterfacesAndSelfTo<PushOutComponent>()
                .AsSingle()
                .WithArguments(_pushCooldown, _pushForce)
                .NonLazy();


            Container.BindInterfacesAndSelfTo<MoveComponent>()
                .AsSingle()
                .WithArguments(_moveSpeed)
                .NonLazy();
        }

        public override void Start()
        {
            var healthComponent = Get<Health>();
            healthComponent.OnDied += () => gameObject.SetActive(false);

            Get<TriggerEntityDetectorComponent>().OnDetected += entity =>
            {
                if (entity.TryGet<Health>(out var health))
                {
                    health.Damage(_damage);
                    Get<PushOutComponent>().Push(entity);
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
            }
            else
            {
                patrolPointsComponent.Next();
            }
        }
    }
}