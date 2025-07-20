using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace SampleGame
{
    public sealed class CharacterInstaller : SceneEntityInstaller<IGameEntity>
    {
        [SerializeField] private int _health = 10;
        [SerializeField] private int _damage = 1;
        [SerializeField] private int _moveRange;
        [SerializeField] private int _attackRange;

        protected override void Install(IGameEntity entity)
        {
            entity.AddCharacterTag();

            entity.AddTransform(transform);
            entity.AddGameObject(gameObject);
            entity.AddHealth(_health);
            entity.AddDamage(_damage);
            entity.AddMoveRange(new Const<int>(_moveRange));
            entity.AddAttackRange(new Const<int>(_attackRange));

            entity.WhenUpdate(_ => entity.GetGameObject().SetActive(entity.GetHealth() > 0));
        }
    }
}