using System;
using System.Collections.Generic;
using Modules.Entities;
using SampleGame.Gameplay;
using Zenject;

namespace SampleGame.App
{
    public sealed class ProductionOrderSerializer : EntityComponentSerializer<ProductionOrderSerializer.Data, ProductionOrder>
    {
        [Inject] private EntityCatalog _entityCatalog;

        protected override Data CreateData(ProductionOrder productionOrder)
        {
            var queue = productionOrder.Queue;
            var names = new string[queue.Count];
            var index = 0;

            foreach (var entityConfig in queue)
            {
                names[index++] = entityConfig.Name;
            }

            return new() {EntityQueue = names};
        }

        protected override void ApplyData(ProductionOrder productionOrder, Data data)
        {
            var names = data.EntityQueue;
            var configs = new List<EntityConfig>(names.Length);

            for (var i = 0; i < names.Length; i++)
            {
                var name = names[i];
                
                if (_entityCatalog.FindConfig(name, out var config))
                {
                    configs.Add(config);
                }
            }

            productionOrder.Queue = configs;
        }

        [Serializable]
        public struct Data
        {
            public string[] EntityQueue;
        }
    }
}