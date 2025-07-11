using Atomic.Entities;
using UnityEngine;

namespace SampleGame
{
    public sealed class DestroyablePropVisualInstaller : SceneEntityInstaller<IGameEntity>
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private string _damagedAnimationKey;
        [SerializeField] private ParticleSystem _damagedVfx;
        [SerializeField] private GameObject _deathVfx;
        [SerializeField] private Transform _deathVfxPoint;

        protected override void Install(IGameEntity entity)
        {
            var gameContext = GameContext.Instance;

            entity.AddAnimator(_animator);

            entity.AddBehaviour(new EventVfxBehaviour(entity.GetDamagedEvent(), _damagedVfx));
            entity.AddBehaviour(new TakeDamageAnimBehaviour(_damagedAnimationKey));
            
            entity.GetDeathEvent().Subscribe(() =>
            {
                gameContext.GetPrefabPool().Rent(_deathVfx, _deathVfxPoint.position, _deathVfxPoint.rotation);
            });
        }
    }
}