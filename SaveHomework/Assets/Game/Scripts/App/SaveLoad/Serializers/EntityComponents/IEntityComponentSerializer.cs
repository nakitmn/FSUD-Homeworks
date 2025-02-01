using System.Collections.Generic;
using Modules.Entities;

namespace SampleGame.App
{
    public interface IEntityComponentSerializer
    {
        bool SerializeComponent(Entity entity, Dictionary<string, string> componentsData);
        bool DeserializeComponent(Entity entity, Dictionary<string, string> componentsData);
    }
}