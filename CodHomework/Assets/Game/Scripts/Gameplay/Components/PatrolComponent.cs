using DG.Tweening;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class PatrolComponent : MonoBehaviour
    {
        [SerializeField] private PatrolPointsComponent _pointsComponent;
        [SerializeField] private float _speed;

        private void Start()
        {
            MoveToCurrentPoint();
        }

        private void MoveToCurrentPoint()
        {
            transform.DOMove(_pointsComponent.Current.position, _speed)
                .SetSpeedBased(true)
                .SetEase(Ease.Linear)
                .SetLink(gameObject)
                .SetUpdate(UpdateType.Fixed)
                .OnComplete(OnDestinated);
        }

        private void OnDestinated()
        {
            _pointsComponent.Next();
            MoveToCurrentPoint();
        }
    }
}