using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace SampleGame
{
    public sealed class CellVisualInstaller : SceneEntityInstaller<IGameEntity>
    {
        [SerializeField] private Renderer _renderer;
        
        protected override void Install(IGameEntity entity)
        {
            entity.AddMaterial(new ReactiveVariable<Material>());
            
            entity.GetMaterial().Subscribe(material => _renderer.material = material);
        }
    }
}