using System;
using Atomic.Entities;

namespace Game.Core
{
    [Serializable]
    public class EntitySpawnConfig
    {
        public ScriptableEntityInstaller character;
        public GameBoardPosition position;
    }
}