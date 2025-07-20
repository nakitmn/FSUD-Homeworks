using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace SampleGame
{
    public sealed class CharacterInstaller : SceneEntityInstaller<IGameEntity>
    {
        [SerializeField] private int _moveRange;
        
        protected override void Install(IGameEntity entity)
        {
            entity.AddCharacterTag();
            
            entity.AddTransform(transform);   
            entity.AddGameObject(gameObject);
            entity.AddMoveRange(new Const<int>(_moveRange));
        }
    }
}