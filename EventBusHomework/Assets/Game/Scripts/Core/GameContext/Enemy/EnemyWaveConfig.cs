using System;
using Atomic.Entities;

namespace SampleGame
{
    [Serializable]
    public class EnemyWaveConfig
    {
        public int turn;
        public ScriptableEntityInstaller prefab;
        public GameBoardPosition[] points;
    }
}