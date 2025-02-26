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

        private PushSideMediator _pushSideMediator;
        private PushUpMediator _pushUpMediator;

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
            jumpComponent.AddCondition(() => Get<Health>().IsAlive);
            jumpComponent.AddCondition(Get<GroundedCheckComponent>().IsGrounded);

            _pushSideMediator = new PushSideMediator(this, _pushSideCooldown, _pushSideForce);
            _pushSideMediator.Install();

            _pushUpMediator = new PushUpMediator(this, _pushUpCooldown, _pushUpForce);
            _pushUpMediator.Install();
        }

        public void Jump()
        {
            Get<JumpComponent>().Jump();
        }

        public void PushUp()
        {
            _pushUpMediator.Push();
        }

        public void PushSide()
        {
            _pushSideMediator.Push();
        }

        private sealed class PushSideMediator
        {
            private readonly IEntity _entity;
            private readonly float _cooldown;
            private readonly float _force;

            private PushComponent _pushComponent;
            private ReloadComponent _reloadComponent;
            private Rigidbody2D _rigidbody;
            private EntityScannerComponent _entityScannerComponent;

            public PushSideMediator(IEntity entity, float cooldown, float force)
            {
                _entity = entity;
                _cooldown = cooldown;
                _force = force;
            }

            public void Install()
            {
                _rigidbody = _entity.Get<Rigidbody2D>();
                _entityScannerComponent = _entity.Get<EntityScannerComponent>();
                _pushComponent = new PushComponent();
                _reloadComponent = new ReloadComponent(_cooldown);
                _pushComponent.AddCondition(() => _entity.Get<Health>().IsAlive);
                _pushComponent.AddCondition(_reloadComponent.IsReady);
            }

            public void Push()
            {
                var entities = _entityScannerComponent.ScanMultiple();
                entities.Remove(_entity);

                foreach (var entity in entities)
                {
                    if (entity.TryGet<Rigidbody2D>(out var rigidbody))
                    {
                        var direction = rigidbody.position - _rigidbody.position;
                        _pushComponent.Push(rigidbody, direction.normalized, _force);
                    }
                }

                _reloadComponent.Reload();
            }
        }

        private sealed class PushUpMediator
        {
            private readonly IEntity _entity;
            private readonly float _cooldown;
            private readonly float _force;

            private PushComponent _pushComponent;
            private ReloadComponent _reloadComponent;
            private Rigidbody2D _rigidbody;
            private EntityScannerComponent _entityScannerComponent;

            public PushUpMediator(IEntity entity, float cooldown, float force)
            {
                _entity = entity;
                _cooldown = cooldown;
                _force = force;
            }

            public void Install()
            {
                _rigidbody = _entity.Get<Rigidbody2D>();
                _entityScannerComponent = _entity.Get<EntityScannerComponent>();
                _pushComponent = new PushComponent();
                _reloadComponent = new ReloadComponent(_cooldown);
                _pushComponent.AddCondition(() => _entity.Get<Health>().IsAlive);
                _pushComponent.AddCondition(_entity.Get<GroundedCheckComponent>().IsGrounded);
                _pushComponent.AddCondition(_reloadComponent.IsReady);
            }

            public void Push()
            {
                var entities = _entityScannerComponent.ScanMultiple();
                entities.Remove(_entity);

                foreach (var entity in entities)
                {
                    if (entity.TryGet<Rigidbody2D>(out var rigidbody))
                    {
                        _pushComponent.Push(rigidbody, Vector2.up, _force);
                    }
                }

                _reloadComponent.Reload();
            }
        }
    }
}