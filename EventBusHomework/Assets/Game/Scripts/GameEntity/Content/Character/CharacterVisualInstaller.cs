using Atomic.Elements;
using Atomic.Entities;
using DG.Tweening;
using UnityEngine;

namespace SampleGame
{
    public sealed class CharacterVisualInstaller : SceneEntityInstaller<IGameEntity>
    {
        [SerializeField] private Transform _visualTransform;
        
        protected override void Install(IGameEntity entity)
        {
            entity.AddVisualTransform(_visualTransform);
            entity.AddSelectedAnimation(new ReactiveVariable<Tween>());
            
            entity.AddBehaviour<HighlightSelectedCharacterBehaviour>();
        }
    }
}