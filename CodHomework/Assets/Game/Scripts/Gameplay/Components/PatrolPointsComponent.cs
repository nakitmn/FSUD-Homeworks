using UnityEngine;

namespace Game.Gameplay
{
    public sealed class PatrolPointsComponent : MonoBehaviour
    {
        [SerializeField] private Transform[] _points;

        private int _index;

        public Transform Current => _points[_index];

        public void Next()
        {
            _index = (int) Mathf.Repeat(_index + 1, _points.Length);
        }
    }
}