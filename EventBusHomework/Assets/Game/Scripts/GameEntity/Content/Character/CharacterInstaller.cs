using Atomic.Entities;

namespace SampleGame
{
    public sealed class CharacterInstaller : SceneEntityInstaller<IGameEntity>
    {
        protected override void Install(IGameEntity entity)
        {
            entity.AddCharacterTag();
            
            entity.AddTransform(transform);   
            entity.AddGameObject(gameObject);
        }
    }
}