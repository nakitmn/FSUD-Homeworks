using UnityEngine;

namespace Game.View
{
    [RequireComponent(typeof(ParticleSystem))]
    public sealed class ParticlePoolReturner : MonoBehaviour
    {
        private ViewContext _viewContext;

        private void Awake()
        {
            _viewContext = ViewContext.Instance;
        }

        private void OnParticleSystemStopped()
        {
            _viewContext.GetPrefabPool().Return(gameObject);
        }
    }
}