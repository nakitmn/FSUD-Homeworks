using Atomic.Elements;
using Atomic.Entities;

namespace SampleGame
{
    public sealed class AbilityRunner : 
        IInit<IGameEntity>,
        IEnable,
        IDisable,
        IDispose,
        IUpdate,
        IFixedUpdate,
        ILateUpdate
    {
        private IReactiveDictionary<string, Ability> _abilityMap;
        private EntityUpdater _entityUpdater;

        public void Init(IGameEntity entity)
        {
            _abilityMap = entity.GetAbilities();
            _entityUpdater = new EntityUpdater();
            
            foreach (var (key, ability) in _abilityMap)
            {
                _entityUpdater.Add(ability);
            }
   
            _abilityMap.OnItemAdded += this.OnAbilityAdded;
            _abilityMap.OnItemRemoved += this.OnAbilityRemoved;
        }

        private void OnAbilityRemoved(string key, Ability ability)
        {
            _entityUpdater.Del(ability);
        }

        private void OnAbilityAdded(string key, Ability ability)
        {
            _entityUpdater.Add(ability);
        }

        public void Enable(in IEntity entity)
        {
            _entityUpdater.Enable();
        }

        public void Disable(in IEntity entity)
        {
            _entityUpdater.Disable();
        }

        public void Dispose(in IEntity entity)
        {
            _entityUpdater.Dispose();
            
            _abilityMap.OnItemAdded -= this.OnAbilityAdded;
            _abilityMap.OnItemRemoved -= this.OnAbilityRemoved;
        }

        public void OnUpdate(in IEntity entity, in float deltaTime)
        {
            _entityUpdater.OnUpdate(deltaTime);
        }

        public void OnFixedUpdate(in IEntity entity, in float deltaTime)
        {
            _entityUpdater.OnFixedUpdate(deltaTime);
        }

        public void OnLateUpdate(in IEntity entity, in float deltaTime)
        {
            _entityUpdater.OnLateUpdate(deltaTime);
        }
    }
}