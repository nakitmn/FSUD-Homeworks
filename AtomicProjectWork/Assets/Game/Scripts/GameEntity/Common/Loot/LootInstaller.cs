using System;
using Atomic.Entities;

namespace SampleGame
{
    [Serializable]
    public class LootInstaller : IEntityInstaller<IGameEntity>
    {
        public SceneEntity[] loot;
        public float dropLootRadius = 2f;
        
        public void Install(IGameEntity entity)
        {
            entity.AddLootableTag();
            entity.AddLoot(loot);
            
            entity.AddBehaviour(new LootDropBehaviour(dropLootRadius));
        }
    }
}