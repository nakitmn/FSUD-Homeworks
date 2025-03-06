using System;
using Leopotam.EcsLite;
using UnityEngine;

namespace SampleGame
{
    [Serializable]
    public sealed class UnitCardConfig
    {
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public Sprite Icon { get; private set; }
        [field: SerializeField] public EcsPrototype Prefab { get; private set; }
        [field: SerializeField] public int Price { get; private set; }
    }
}