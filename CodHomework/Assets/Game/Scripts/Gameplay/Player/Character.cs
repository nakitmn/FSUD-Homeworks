using UnityEngine;

namespace Game.Gameplay
{
    public sealed class Character : MonoEntity
    {
        [SerializeField] private Transform _flipTransform;
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _jumpForce;
        
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
        }

        public override void Start()
        {
            Get<JumpComponent>().AddCondition(Get<GroundedCheckComponent>().IsGrounded);
        }
    }
}