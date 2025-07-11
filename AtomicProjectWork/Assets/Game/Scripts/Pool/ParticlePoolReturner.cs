using UnityEngine;

namespace SampleGame
{
    [RequireComponent(typeof(ParticleSystem))]
    public sealed class ParticlePoolReturner : MonoBehaviour
    {
        private GameContext _gameContext;

        private void Awake()
        {
            _gameContext = GameContext.Instance;
        }

        private void OnParticleSystemStopped()
        {
            _gameContext.GetPrefabPool().Return(gameObject);
        }
    }
}