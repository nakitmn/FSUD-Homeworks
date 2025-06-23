using Fusion;
using UnityEngine;

namespace Game
{
    public sealed class PlayerInput : MonoBehaviour
    {
        [SerializeField] private NetworkEvents _networkEvents;

        private void OnEnable()
        {
            _networkEvents.OnInput.AddListener(OnInput);
        }

        private void OnDisable()
        {
            _networkEvents.OnInput.RemoveListener(OnInput);
        }

        private void OnInput(NetworkRunner runner, NetworkInput input)
        {
            var moveDirection = new Vector3(
                Input.GetAxisRaw("Horizontal"),
                0f,
                Input.GetAxisRaw("Vertical")
            );

            var buttons = new NetworkButtons();
            buttons.Set(PlayerKeys.Mine, Input.GetKey(KeyCode.Q));
            buttons.Set(PlayerKeys.Turret, Input.GetKey(KeyCode.E));
            
            var inputData = new InputData
            {
                moveDirection = moveDirection.normalized,
                buttons = buttons
            };

            input.Set(inputData);
        }
    }
}