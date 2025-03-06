using System;
using UnityEngine;

namespace SampleGame
{
    [Serializable]
    public sealed class SceneData
    {
        public Transform[] redSpawnPoints;
        public Transform[] blueSpawnPoints;
    }
}