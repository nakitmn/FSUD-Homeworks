using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace SampleGame
{
    public sealed class RangerUnitFireSystem : IEcsRunSystem
    {
        private readonly EcsPrototype _projectile;

        private readonly EcsFilterInject<Inc<RangerCombatTag>> _units;
        private readonly EcsPoolInject<UnitFireRequired> _firesRequired;
        private readonly EcsUseCaseInject<HealthUseCase> _healthUseCase;
        private readonly EcsUseCaseInject<FireUseCase> _fireUseCase;
        private readonly EcsEventInject<FireEvent> _fireEvents;
        private readonly EcsWorldInject _world;

        public RangerUnitFireSystem(EcsPrototype projectile)
        {
            _projectile = projectile;
        }

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
            
            if (!_healthUseCase.Value.Exists(entity))
                return;

            if (!_fireUseCase.Value.IsCooldownExpired(entity))
                return;
            
            if (_fireUseCase.Value.IsDelayEnabled(entity) == false)
            {
                _fireUseCase.Value.ResetDelay(entity);
                _fireEvents.Value.Fire(new FireEvent {entity = _world.Value.PackEntity(entity)});
                return;
            }
            
            if (_fireUseCase.Value.IsDelayExpired(entity) == false)
            {
                return;
            }
            
            _fireUseCase.Value.DisableFireDelay(entity);
            _fireUseCase.Value.FireProjectile(entity, _projectile);
            _fireUseCase.Value.ResetCooldown(entity);
        }
    }
}