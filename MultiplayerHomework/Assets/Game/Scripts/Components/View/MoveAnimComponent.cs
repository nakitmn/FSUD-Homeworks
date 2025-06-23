using UnityEngine;

namespace Game
{
    public sealed class MoveAnimComponent : MonoBehaviour
    {
        private static readonly int IsMoving = Animator.StringToHash("IsMoving");

        [SerializeField] private Animator _animator;
        [SerializeField] private MoveComponent _moveComponent;

        private void OnEnable()
        {
            _moveComponent.OnMoveStateChanged += OnMoveStateChanged;
        }

        private void OnDisable()
        {
            _moveComponent.OnMoveStateChanged -= OnMoveStateChanged;
        }

        private void OnMoveStateChanged(bool isMoving)
        {
            _animator.SetBool(IsMoving, isMoving);
        }
    }
}