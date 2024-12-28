using Modules;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class PlayerInput : IPlayerInput
    {
        public SnakeDirection Direction
        {
            get
            {
                var x = Input.GetAxisRaw("Horizontal");
                var y = Input.GetAxisRaw("Vertical");

                if (x < 0f)
                {
                    return SnakeDirection.LEFT;
                }

                if (x > 0f)
                {
                    return SnakeDirection.RIGHT;
                }

                if (y < 0f)
                {
                    return SnakeDirection.DOWN;
                }

                if (y > 0f)
                {
                    return SnakeDirection.UP;
                }

                return SnakeDirection.NONE;
            }
        }
    }
}