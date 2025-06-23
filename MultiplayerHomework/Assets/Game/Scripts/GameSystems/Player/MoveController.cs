using UnityEngine;

namespace Game
{
    public sealed class MoveController : MonoBehaviour
    {
        [SerializeField] private InputReceiver _inputReceiver;
        [SerializeField] private MoveComponent _moveComponent;
        [SerializeField] private RotationComponent _rotationComponent;

        private void OnEnable()
        {
            _inputReceiver.OnMove += OnMove;
        }

        private void OnDisable()
        {
            _inputReceiver.OnMove -= OnMove;
        }

        private void OnMove(Vector3 moveDirection, float deltaTime)
        {
            _moveComponent.IsMoving = moveDirection != Vector3.zero;
            _moveComponent.MoveStep(moveDirection, deltaTime);
            _rotationComponent.RotateStep(moveDirection, deltaTime);
        }
    }
}