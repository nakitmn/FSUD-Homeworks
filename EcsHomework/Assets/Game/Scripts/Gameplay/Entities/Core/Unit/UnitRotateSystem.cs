using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace SampleGame
{
    public sealed class UnitRotateSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<UnitTag>> _units;
        private readonly EcsPoolInject<UnitRotateDirection> _unitRotateDirections;
        private readonly EcsUseCaseInject<HealthUseCase> _healthUseCase;
        private readonly EcsUseCaseInject<RotateUseCase> _rotateUseCase;

        public void Run(IEcsSystems systems)
        {
            foreach (int entity in _units.Value)
            {
                bool healthExists = _healthUseCase.Value.Exists(entity);
                _rotateUseCase.Value.SetEnabled(entity, healthExists);
                
                ref UnitRotateDirection rotateDirection = ref _unitRotateDirections.Value.Get(entity);
                _rotateUseCase.Value.SetDirection(entity, rotateDirection.value);
            }
        }
    }
}