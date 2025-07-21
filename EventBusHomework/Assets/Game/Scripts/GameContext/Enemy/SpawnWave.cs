using System;
using Atomic.Entities;

namespace SampleGame
{
    [Serializable]
    public struct SpawnWave
    {
        public int turn;
        public SceneEntity prefab;
        public GameBoardPosition[] points;
    }
}