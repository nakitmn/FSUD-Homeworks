using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace SampleGame
{
    public sealed class DeathSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<DeathTag>> _deathables;
        private readonly EcsUseCaseInject<HealthUseCase> _healthUseCase;
        private readonly EcsEventInject<DespawnRequest> _despawnRequest;
        private readonly EcsEventInject<DeadEvent> _deadEvent;
        private readonly EcsWorldInject _world;

        public void Run(IEcsSystems systems)
        {
            foreach (int entity in _deathables.Value)
            {
                if (_healthUseCase.Value.Exists(entity))
                {
                    continue;
                }

                _deadEvent.Value.Fire(new DeadEvent() {entity = _world.Value.PackEntity(entity)});
                _despawnRequest.Value.Fire(new DespawnRequest {entity = entity});
            }
        }
    }
}