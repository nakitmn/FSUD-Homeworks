using System;
using Atomic.Entities;

namespace SampleGame
{
    [Serializable]
    public class EntitySpawnConfig
    {
        public ScriptableEntityInstaller character;
        public GameBoardPosition position;
    }
}