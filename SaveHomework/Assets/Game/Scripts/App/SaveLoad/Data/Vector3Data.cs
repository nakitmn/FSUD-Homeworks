using System;
using UnityEngine;

namespace SampleGame.App
{
    [Serializable]
    public struct Vector3Data
    {
        public float X;
        public float Y;
        public float Z;

        public static Vector3Data FromVector3(Vector3 vector)
        {
            return new()
            {
                X = vector.x,
                Y = vector.y,
                Z = vector.z,
            };
        }

        public static Vector3 ToVector3(Vector3Data data)
        {
            return new(
                data.X,
                data.Y,
                data.Z
            );
        }
    }
}