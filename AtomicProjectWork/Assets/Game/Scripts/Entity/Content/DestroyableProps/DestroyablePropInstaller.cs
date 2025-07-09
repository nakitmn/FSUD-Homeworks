using Atomic.Entities;
using UnityEngine;

namespace SampleGame
{
    public class DestroyablePropInstaller : SceneEntityInstaller
    {
        [SerializeField] private LifeInstaller _lifeInstaller;
        [SerializeField] private LootInstaller _lootInstaller;
        
        public override void Install(IEntity entity)
        {
            entity.AddGameObject(gameObject);
            entity.AddTransform(transform);
            
            _lifeInstaller.Install(entity);
            _lootInstaller.Install(entity);
            
            entity.GetDeathEvent().Subscribe(() =>
            {
                gameObject.SetActive(false);
            });
        }
    }
}