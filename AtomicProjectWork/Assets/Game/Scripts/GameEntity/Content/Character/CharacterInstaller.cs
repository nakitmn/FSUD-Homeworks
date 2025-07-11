using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;
using UnityEngine.AI;

namespace SampleGame
{
    public sealed class CharacterInstaller : SceneEntityInstaller<IGameEntity>
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

        protected override void Install(IGameEntity entity)
        {
            entity.AddFirePoint(_firePoint);
            entity.AddEffects(new ReactiveDictionary<string, Effect>());

            InstallMain(entity);
            InstallMove(entity);

            _lifeInstaller.Install(entity);
            _interactInstaller.Install(entity);
            _lootInstaller.Install(entity);
            _manaInstaller.Install(entity);

            InstallAbilities(entity);
        }

        private void InstallAbilities(IGameEntity entity)
        {
            _abilitySystemInstaller.Install(entity);

            entity.AddSelectAbilityCondition(
                new AndExpression(
                    () => AbilityUseCase.IsSelectedAbilityRunning(entity) == false
                )
            );

            entity.AddSelectAbilityAction(new BaseAction<Ability>(ability =>
            {
                if (entity.GetSelectAbilityCondition().Value == false)
                {
                    return;
                }

                entity.GetSelectedAbility().Value = ability;
            }));
        }

        private void InstallMain(IGameEntity entity)
        {
            entity.AddGameObject(_gameObject);
            entity.AddTransform(_transform);
            entity.AddRigidbody(_rigidbody);
            entity.AddTrigger(_triggerEventReceiver);
            entity.AddNavAgent(_agent);
            _agent.updateRotation = false;
        }

        private void InstallMove(IGameEntity entity)
        {
            entity.AddMoveableTag();
            entity.AddMoveSpeed(new ReactiveFloat(_moveSpeed));
            entity.AddMoveCondition(
                new AndExpression(
                    () => HealthUseCase.IsAlive(entity),
                    () => AbilityUseCase.IsSelectedAbilityRunning(entity) == false
                )
            );
            entity.AddNormalizedCurrentSpeed(new BaseFunction<float>(() => _agent.velocity.magnitude / _agent.speed));
            entity.AddAngularDirection(new BaseFunction<Vector3>(() => _agent.velocity));
            entity.AddAngularSpeed(new Const<float>(_angularSpeed));
            entity.AddStopAction(new BaseAction(() => _agent.SetDestination(_transform.position)));

            entity.AddMovePointAction(new BaseAction<Vector3>(point =>
            {
                if (entity.GetMoveCondition().Value == false)
                {
                    return;
                }

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
            entity.AddBehaviour<RotateTowardsBehaviour>();

            entity.GetMoveSpeed().Observe(speed => entity.GetNavAgent().speed = speed);
        }
    }
}