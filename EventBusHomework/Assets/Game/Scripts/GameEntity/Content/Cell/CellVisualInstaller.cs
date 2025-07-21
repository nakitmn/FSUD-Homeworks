using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace SampleGame
{
    public sealed class CellVisualInstaller : SceneEntityInstaller<IGameEntity>
    {
        [SerializeField] private Renderer _renderer;
        
        protected override void Install(IGameEntity context)
        {
            context.AddMaterial(new ReactiveVariable<Material>());
            
            context.GetMaterial().Subscribe(material => _renderer.material = material);
        }
    }
}