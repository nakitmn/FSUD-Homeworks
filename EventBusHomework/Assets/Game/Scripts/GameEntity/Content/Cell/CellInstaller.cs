using Atomic.Elements;
using Atomic.Entities;

namespace SampleGame
{
    public sealed class CellInstaller : SceneEntityInstaller<IGameEntity>
    {
        protected override void Install(IGameEntity context)
        {
            context.AddCellTag();
            
            context.AddTransform(transform);
            context.AddGameObject(gameObject);
            
            context.AddBoardPosition(new ReactiveVariable<GameBoardPosition>());
        }
    }
}