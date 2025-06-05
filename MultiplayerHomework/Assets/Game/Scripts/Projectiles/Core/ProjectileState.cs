using System;
using Fusion;
using UnityEngine;

namespace Game
{
    [Serializable]
    public struct ProjectileState : INetworkStruct
    {
        public ProjectileType type;
        public int tick;
        public Vector3 position; 
        public Quaternion rotation;

        public bool IsActive => this.tick > 0;
        public void SetInactive() => this.tick = 0;
    }
}