using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;
using UnityEngine.AI;

namespace SampleGame
{
    public sealed class CharacterInstaller : SceneEntityInstaller
    {
        [SerializeField] private GameObject _gameObject;
        [SerializeField] private Transform _transform;
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private TriggerEventReceiver _triggerEventReceiver;
        [SerializeField] private float _moveSpeed = 3;
        [SerializeField] private float _angularSpeed = 15;
        [SerializeField] private InteractInstaller _interactInstaller;
        [SerializeField] private AbilitySystemInstaller _abilitySystemInstaller;
        [SerializeField] private Transform _firePoint;
        [SerializeField] private LifeInstaller _lifeInstaller;
        [SerializeField] private LootInstaller _lootInstaller;
        [SerializeField] private ManaSystemInstaller _manaInstaller;
        
        public override void Install(IEntity entity)
        {
            entity.AddFirePoint(_firePoint);
            entity.AddEffects(new ReactiveDictionary<string, EffectInstance>());
            
            InstallMain(entity);
            InstallMove(entity);
            
            _lifeInstaller.Install(entity);
            _interactInstaller.Install(entity);
            _lootInstaller.Install(entity);
            _manaInstaller.Install(entity);
            _abilitySystemInstaller.Install(entity);
        }

        private void InstallMain(IEntity entity)
        {
            entity.AddGameObject(_gameObject);
            entity.AddTransform(_transform);
            entity.AddRigidbody(_rigidbody);
            entity.AddTrigger(_triggerEventReceiver);
            entity.AddNavAgent(_agent);
        }

        private void InstallMove(IEntity entity)
        {
            entity.AddMoveableTag();
            entity.AddMoveSpeed(new ReactiveFloat(_moveSpeed));
            entity.AddMoveCondition(new AndExpression(() => HealthUseCase.IsAlive(entity)));
            entity.AddMoveDirection(new ReactiveVector3());
            entity.AddMovePointAction(new BaseAction<Vector3>(point =>
            {
                entity.GetNavAgent().SetDestination(point);
            }));
            
            entity.AddTeleportAction(new BaseAction<Vector3>(point =>
            {
                var navAgent = entity.GetNavAgent();
                entity.GetTransform().position = point;
                navAgent.Warp(point);
                navAgent.SetDestination(point);
            }));
            
            entity.AddIsMoving(new BaseFunction<bool>(() => _agent.velocity != Vector3.zero));
            entity.AddBehaviour<MoveTowardsBehaviour>();
        }
    }
}