using Atomic.Entities;
using UnityEngine;

namespace SampleGame
{
    public sealed class DestroyablePropInstaller : SceneEntityInstaller<IGameEntity>
    {
        [SerializeField] private LifeInstaller _lifeInstaller;
        [SerializeField] private LootInstaller _lootInstaller;

        protected override void Install(IGameEntity entity)
        {
            entity.AddGameObject(gameObject);
            entity.AddTransform(transform);

            _lifeInstaller.Install(entity);
            _lootInstaller.Install(entity);

            entity.GetDeathEvent().Subscribe(() => { gameObject.SetActive(false); });
        }
    }
}