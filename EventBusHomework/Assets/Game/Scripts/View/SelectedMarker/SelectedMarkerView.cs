using UnityEngine;
using UnityEngine.Animations;

namespace Game.View
{
    public sealed class SelectedMarkerView : MonoBehaviour
    {
        [SerializeField] private PositionConstraint _positionConstraint;

        public void SetTarget(Transform target)
        {
            _positionConstraint.SetSource(0, new ConstraintSource()
            {
                sourceTransform = target,
                weight = 1f
            });
        }

        public void SetActive(bool active)
        {
            gameObject.SetActive(active);
        }
    }
}