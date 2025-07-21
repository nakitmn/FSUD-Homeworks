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

        protected override void Install(IGameEntity context)
        {
            context.AddCharacterTag();

            context.AddTransform(transform);
            context.AddGameObject(gameObject);
            context.AddHealth(_health);
            context.AddDamage(_damage);
            context.AddMoveRange(new Const<int>(_moveRange));
            context.AddAttackRange(new Const<int>(_attackRange));
            
            context.AddMaxMovesPerTurn(new Const<int>(_movesPerTurn));
            context.AddMaxAttacksPerTurn(new Const<int>(_attacksPerTurn));
            context.AddCurrentMovesCount(new ReactiveInt());
            context.AddCurrentAttacksCount(new ReactiveInt());

            //entity.WhenUpdate(_ => entity.GetGameObject().SetActive(entity.GetHealth() > 0));
        }
    }
}