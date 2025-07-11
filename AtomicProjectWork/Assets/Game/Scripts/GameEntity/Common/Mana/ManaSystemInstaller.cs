using System;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace SampleGame
{
    [Serializable]
    public sealed class ManaSystemInstaller : IEntityInstaller<IGameEntity>
    {
        [SerializeField] private Const<int> _maxMana = 10;
        [SerializeField] private float _restoreManaPeriod;
        [SerializeField] private Const<int> _restoreAmount = 1;

        public void Install(IGameEntity entity)
        {
            entity.AddMaxMana(_maxMana);
            entity.AddCurrentMana(new ReactiveInt(_maxMana.Value));
            entity.AddBehaviour(new RestoreManaBehaviour(new Cooldown(_restoreManaPeriod), _restoreAmount));
        }
    }
}