using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace SampleGame
{
    public sealed class CharacterMoveSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<CharacterTag>> _characters;
        private readonly EcsPoolInject<UnitDirection> _unitDirections;
        private readonly EcsUseCaseInject<MoveUseCase> _moveUseCase;
        private readonly EcsUseCaseInject<HealthUseCase> _healthUseCase;

        public void Run(IEcsSystems systems)
        {
            foreach (int entity in _characters.Value)
            {
                bool healthExists = _healthUseCase.Value.Exists(entity);
                _moveUseCase.Value.SetEnabled(entity, healthExists);
                
                ref UnitDirection unitDirection = ref _unitDirections.Value.Get(entity);
                _moveUseCase.Value.SetDirection(entity, unitDirection.value);
            }
        }
    }
}