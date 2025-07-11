using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace SampleGame
{
    public sealed class EffectPickUpInstaller : SceneEntityInstaller<IGameEntity>
    {
        [SerializeField]
        private EffectConfig _effect;
        
        protected override void Install(IGameEntity entity)
        {
            GameContext gameContext = GameContext.Instance;

            entity.AddTransform(this.transform);
            
            entity.AddInteractibleTag();
            entity.AddInteractAction(new BaseAction<IGameEntity>(character =>
            {
                if (EffectUseCase.Apply(character, _effect))
                    gameContext.GetEntityPool().Return(entity);
            }));
        }
    }
}