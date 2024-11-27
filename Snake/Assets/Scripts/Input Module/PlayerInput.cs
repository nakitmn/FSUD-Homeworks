using UnityEngine;

namespace Input_Module
{
    public sealed class PlayerInput : IPlayerInput
    {
        public Vector2 Direction => new(
            Input.GetAxis("Horizontal"),
            Input.GetAxis("Vertical")
        );
    }
}