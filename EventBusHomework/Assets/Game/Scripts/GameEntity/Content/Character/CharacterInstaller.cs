using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace SampleGame
{
    public sealed class CharacterInstaller : SceneEntityInstaller<IGameEntity>
    {
        [SerializeField] private int _health = 10;
        [SerializeField] private int _movesPerTurn = 1;
        [SerializeField] private int _attacksPerTurn = 1;
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

            entity.AddMaxMovesPerTurn(new Const<int>(_movesPerTurn));
            entity.AddMaxAttacksPerTurn(new Const<int>(_attacksPerTurn));
            entity.AddCurrentMovesCount(new ReactiveInt());
            entity.AddCurrentAttacksCount(new ReactiveInt());

            //entity.WhenUpdate(_ => entity.GetGameObject().SetActive(entity.GetHealth() > 0));
        }
    }
}