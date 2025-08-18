using SampleGame;
using UnityEngine;

namespace Game.View
{
    public sealed class WaterSplashParticle : MonoBehaviour
    {
        [SerializeField] private GameObject _prefab;
        
        private GenericPrefabPool _prefabPool;

        private void Awake()
        {
            _prefabPool = ViewContext.Instance.GetPrefabPool();
        }

        private void OnTriggerEnter(Collider other)
        {
            _prefabPool.Rent(_prefab, other.transform.position, _prefab.transform.rotation);
        }
    }
}