using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace SampleGame
{
    public sealed class ArcherFireSystem : IEcsRunSystem
    {
        private readonly EcsPrototype _projectile;

        private readonly EcsFilterInject<Inc<ArcherTag>> _characters;
        private readonly EcsPoolInject<UnitFireRequired> _firesRequired;
        private readonly EcsUseCaseInject<HealthUseCase> _healthUseCase;
        private readonly EcsUseCaseInject<FireUseCase> _fireUseCase;
        private readonly EcsEventInject<FireEvent> _fireEvents;
        private readonly EcsWorldInject _world;

        public ArcherFireSystem(EcsPrototype projectile)
        {
            _projectile = projectile;
        }

        public void Run(IEcsSystems systems)
        {
            foreach (int entity in _characters.Value)
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

            //act
            _fireUseCase.Value.FireProjectile(entity, _projectile);
            _fireUseCase.Value.ResetCooldown(entity);

            //event
            _fireEvents.Value.Fire(new FireEvent {entity = _world.Value.PackEntity(entity)});
        }
    }
}