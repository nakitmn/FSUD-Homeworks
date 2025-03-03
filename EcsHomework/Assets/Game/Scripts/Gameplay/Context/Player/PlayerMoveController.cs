using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Unity.Mathematics;

namespace SampleGame
{
    public sealed class PlayerMoveController : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<UnitDirection>> _units;
        private readonly EcsSingletonInject<InputData> _inputData;
        private readonly EcsUseCaseInject<TeamUseCase> _teamUseCase;

        public void Run(IEcsSystems systems)
        {
            ref float3 moveDirection = ref _inputData.Value.moveDirection;

            foreach (int entity in _units.Value)
                if (_teamUseCase.Value.IsTeam(entity, TeamType.BLUE))
                    _units.Pools.Inc1.Get(entity).value = moveDirection;
        }
    }
}