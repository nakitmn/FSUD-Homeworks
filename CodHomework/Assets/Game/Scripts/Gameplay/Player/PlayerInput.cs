using UnityEngine;

namespace Game.Gameplay
{
    public sealed class PlayerInput
    {
        public float HorizontalDirection => Input.GetAxisRaw("Horizontal");
        public Vector2 MoveDirection => new(HorizontalDirection, 0f);

        public bool IsJump => Input.GetKeyDown(KeyCode.Space);
    }
}