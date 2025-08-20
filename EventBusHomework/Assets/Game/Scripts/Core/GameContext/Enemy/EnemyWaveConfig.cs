using System;
using Atomic.Entities;

namespace Game.Core
{
    [Serializable]
    public class EnemyWaveConfig
    {
        public int turn;
        public ScriptableEntityInstaller prefab;
        public GameBoardPosition[] points;
    }
}