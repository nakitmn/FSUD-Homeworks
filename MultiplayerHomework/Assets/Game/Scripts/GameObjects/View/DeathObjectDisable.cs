using UnityEngine;

namespace Game
{
    public sealed class DeathObjectDisable : MonoBehaviour
    {
        [SerializeField] private DeathComponent _deathComponent;
        [SerializeField] private GameObject _gameObject;

        private void OnEnable()
        {
            _deathComponent.OnDeadChanged += OnDeadChanged;
        }

        private void OnDisable()
        {
            _deathComponent.OnDeadChanged -= OnDeadChanged;
        }

        private void OnDeadChanged(bool isDead)
        {
            if (isDead)
            {
                _gameObject.SetActive(false);
            }
        }
    }
}