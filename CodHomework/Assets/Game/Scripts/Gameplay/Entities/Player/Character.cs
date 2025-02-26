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
        
        private JumpMediator _jumpMediator;

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

            _jumpMediator = new JumpMediator(this, _jumpCooldown, _jumpForce);
            _jumpMediator.Install();
            
            var moveComponent = Get<MoveComponent>();
            moveComponent.AddCondition(() => healthComponent.IsAlive);
            
            var faceComponent = Get<FaceComponent>();
            faceComponent.AddCondition(() => healthComponent.IsAlive);
        }

        public void Jump()
        {
            _jumpMediator.Jump();
        }
        
        private sealed class JumpMediator
        {
            private readonly IEntity _entity;
            private readonly float _cooldown;
            private readonly float _force;

            private PushComponent _pushComponent;
            private ReloadComponent _reloadComponent;
            private Rigidbody2D _rigidbody;

            public JumpMediator(IEntity entity, float cooldown, float force)
            {
                _entity = entity;
                _cooldown = cooldown;
                _force = force;
            }

            public void Install()
            {
                _rigidbody = _entity.Get<Rigidbody2D>();
                _pushComponent = new PushComponent(Vector2.up, _force);
                _reloadComponent = new ReloadComponent(_cooldown);
                _pushComponent.AddCondition(() => _entity.Get<Health>().IsAlive);
                _pushComponent.AddCondition(_entity.Get<GroundedCheckComponent>().IsGrounded);
                _pushComponent.AddCondition(_reloadComponent.IsReady);
                _pushComponent.OnPushed += _reloadComponent.Reload;
            }

            public void Jump()
            {
                _pushComponent.Push(_rigidbody);
            }
        }
    }
}