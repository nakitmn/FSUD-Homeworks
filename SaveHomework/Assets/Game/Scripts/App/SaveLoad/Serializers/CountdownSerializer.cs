using System.Collections.Generic;
using Modules.Entities;
using SampleGame.Gameplay;

namespace SampleGame.App
{
    public sealed class CountdownSerializer : GameSerializer<EntityWorld, CountdownData[]>
    {
        protected override CountdownData[] Serialize(EntityWorld world)
        {
            var entities = world.GetAll();
            var countdownDatas = new List<CountdownData>();
            
            foreach (var entity in entities)
            {
                var countdown = entity.GetComponent<Countdown>();

                if (countdown == null)
                {
                    continue;
                }

                var data = new CountdownData()
                {
                    EntityId = entity.Id,
                    Current = countdown.Current
                };
                
                countdownDatas.Add(data);
            }

            return countdownDatas.ToArray();
        }
        
        protected override void Deserialize(EntityWorld world, CountdownData[] data)
        {
            foreach (var countdownData in data)
            {
                if (world.Has(countdownData.EntityId) == false)
                {
                    continue;
                }
                
                var entity = world.Get(countdownData.EntityId);
                
                var countdown = entity.GetComponent<Countdown>();
                if (countdown == null)
                {
                    continue;
                }
                    
                countdown.Current = countdownData.Current;
            }
        }
    }
}