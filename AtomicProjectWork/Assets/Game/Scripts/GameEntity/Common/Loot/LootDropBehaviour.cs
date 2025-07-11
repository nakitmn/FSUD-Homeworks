using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace SampleGame
{
    public sealed class LootDropBehaviour : IInit<IGameEntity>, IDispose
    {
        private readonly float _dropRadius;

        private SceneEntity[] _loot;
        private IEvent _deathEvent;
        private Transform _transform;
        private IGameContext _gameContext;

        public LootDropBehaviour(float dropRadius)
        {
            _dropRadius = dropRadius;
        }

        public void Init(IGameEntity entity)
        {
            _gameContext = GameContext.Instance;
            _transform = entity.GetTransform();
            _loot = entity.GetLoot();
            _deathEvent = entity.GetDeathEvent();

            _deathEvent.Subscribe(OnDeath);
        }

        public void Dispose(in IEntity entity)
        {
            _deathEvent.Unsubscribe(OnDeath);
        }

        private void OnDeath()
        {
            LootUseCase.DropLoot(_gameContext, _transform.position, _loot, _dropRadius);
        }
    }
}