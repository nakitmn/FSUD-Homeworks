using Atomic.Elements;
using Atomic.Entities;

namespace SampleGame
{
    public sealed class CellInstaller : SceneEntityInstaller<IGameEntity>
    {
        protected override void Install(IGameEntity entity)
        {
            entity.AddCellTag();
            
            entity.AddTransform(transform);
            entity.AddGameObject(gameObject);
            
            entity.AddBoardPosition(new ReactiveVariable<GameBoardPosition>());
        }
    }
}