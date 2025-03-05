using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using SampleGame.Entities.Core.Target;

namespace SampleGame
{
    public sealed class MeleeUnitFireSystem : IEcsRunSystem
    {
        private readonly EcsPrototype _projectile;

        private readonly EcsFilterInject<Inc<MeleeCombatTag>> _units;
        private readonly EcsPoolInject<UnitFireRequired> _firesRequired;
        private readonly EcsPoolInject<Damage> _damages;
        private readonly EcsUseCaseInject<HealthUseCase> _healthUseCase;
        private readonly EcsUseCaseInject<TargetUseCase> _targetUseCase;
        private readonly EcsUseCaseInject<FireUseCase> _fireUseCase;
        private readonly EcsUseCaseInject<TakeDamageUseCase> _takeDamageUseCase;
        private readonly EcsEventInject<FireEvent> _fireEvents;
        private readonly EcsWorldInject _world;

        public void Run(IEcsSystems systems)
        {
            foreach (int entity in _units.Value)
                this.Fire(entity);
        }

        private void Fire(int entity)
        {
            //cond
            if (!_firesRequired.Value.Get(entity).value)
                return;

            if (!_fireUseCase.Value.IsCooldownExpired(entity))
                return;

            if (!_healthUseCase.Value.Exists(entity))
                return;

            if (_targetUseCase.Value.IsTargetExist(entity, out var target) == false)
                return;
            
            //act
            ref var damage = ref _damages.Value.Get(entity);
            _takeDamageUseCase.Value.TakeDamage(target, damage.value, _world.Value.PackEntity(entity));
            _fireUseCase.Value.ResetCooldown(entity);

            //event
            _fireEvents.Value.Fire(new FireEvent
            {
                entity = _world.Value.PackEntity(entity)
            });
        }
    }
}