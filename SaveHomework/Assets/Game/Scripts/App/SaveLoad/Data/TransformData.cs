using System;
using UnityEngine;

namespace SampleGame.App
{
    [Serializable]
    public struct TransformData
    {
        public Vector3Data Position;
        public Vector3Data Rotation;

        public static TransformData FromTransform(Transform transform)
        {
            return new()
            {
                Position = Vector3Data.FromVector3(transform.position),
                Rotation = Vector3Data.FromVector3(transform.rotation.eulerAngles)
            };
        }
    }
}