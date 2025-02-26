using UnityEngine;

namespace Game.Gameplay
{
    public sealed class Character : MonoEntity
    {
        [SerializeField] private Transform _flipTransform;
        [SerializeField] private float _moveSpeed;
        
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
        }
    }
}