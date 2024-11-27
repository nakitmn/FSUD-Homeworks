using UnityEngine;

namespace Input_Module
{
    public sealed class PlayerInput : IPlayerInput
    {
        public Vector2 Direction => new(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")
        );
    }
}