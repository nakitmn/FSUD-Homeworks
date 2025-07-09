using UnityEngine;

namespace SampleGame
{
    [RequireComponent(typeof(ParticlesEventReceiver))]
    public sealed class ParticlePoolReturner : MonoBehaviour
    {
        private ParticlesEventReceiver _particlesEventReceiver;
        private GameContext _gameContext;

        private void Awake()
        {
            _particlesEventReceiver = GetComponent<ParticlesEventReceiver>();
            _gameContext = GameContext.Instance;
        }

        private void OnEnable()
        {
            _particlesEventReceiver.OnStopped += ReturnToPool;
        }

        private void OnDisable()
        {
            _particlesEventReceiver.OnStopped -= ReturnToPool;
        }

        private void ReturnToPool()
        {
            _gameContext.GetPrefabPool().Return(gameObject);
        }
    }
}