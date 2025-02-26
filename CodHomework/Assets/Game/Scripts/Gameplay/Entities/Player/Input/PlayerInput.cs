using UnityEngine;

namespace Game.Gameplay
{
    public sealed class PlayerInput
    {
        public float HorizontalDirection => Input.GetAxisRaw("Horizontal");
        public Vector2 MoveDirection => new(HorizontalDirection, 0f);

        public bool IsJump => Input.GetKeyDown(KeyCode.Space);
        public bool IsPushUp => Input.GetKeyDown(KeyCode.W) || Input.GetMouseButtonDown(1);
        public bool IsPushSide => Input.GetKeyDown(KeyCode.S) || Input.GetMouseButtonDown(0);
    }
}