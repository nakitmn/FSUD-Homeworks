using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace SampleGame
{
    public sealed class CellVisualInstaller : SceneEntityInstaller<IGameEntity>
    {
        [SerializeField] private Renderer _renderer;
        [SerializeField] private Material _highlightedMaterial;
        
        protected override void Install(IGameEntity entity)
        {
            entity.AddDefaultMaterial(new ReactiveVariable<Material>());
            entity.AddCurrentMaterial(new ReactiveVariable<Material>());
            entity.AddHighlightedMaterial(new ReactiveVariable<Material>(_highlightedMaterial));
            
            entity.GetCurrentMaterial().Subscribe(material => _renderer.material = material);
            
            entity.AddBehaviour<HighlightSpawnCellBehaviour>();
        }
    }
}