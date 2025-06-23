using UnityEngine;

namespace Game
{
    public sealed class DeathVfx : MonoBehaviour
    {
        [SerializeField] private DeathComponent _deathComponent;
        [SerializeField] private ParticleSpawner _vfx;

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
                _vfx.Play();
            }
        }
    }
}