using UnityEngine;

namespace Game
{
    public sealed class InstantiateParticlePlayer : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _effectPrefab;
        [SerializeField] private Transform _playPoint;

        public void Play()
        {
            Instantiate(_effectPrefab, _playPoint.position, _playPoint.rotation, null);
        }
    }
}