using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Core
{
    [CreateAssetMenu(menuName = "Game/EnemyInstaller")]
    public sealed class EnemyInstaller : ScriptableEntityInstaller<IGameEntity>
    {
        [SerializeField] private int _health = 10;
        [SerializeField] private Const<int> _movesPerTurn = 1;
        [SerializeField] private Const<int> _attacksPerTurn = 1;
        [SerializeField] private Const<int> _damage = 1;
        [SerializeField] private Const<int> _moveRange;
        [SerializeField] private Const<int> _attackRange;

        protected override void Install(IGameEntity entity)
        {
            entity.AddEnemyTag();
            
            entity.AddHealth(new ReactiveInt(_health));
            entity.AddMaxHealth(new ReactiveInt(_health));
            entity.AddDamage(_damage);
            entity.AddMoveRange(_moveRange);
            entity.AddAttackRange(_attackRange);
            
            entity.AddMaxMovesPerTurn(_movesPerTurn);
            entity.AddMaxAttacksPerTurn(_attacksPerTurn);
            entity.AddCurrentMovesCount(new ReactiveInt());
            entity.AddCurrentAttacksCount(new ReactiveInt());
            
            entity.AddTarget(new ReactiveVariable<IGameEntity>());
        }
    }
}