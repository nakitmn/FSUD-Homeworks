using UnityEngine;

namespace SampleGame
{
    public sealed class TileVisualRandomizer : MonoBehaviour
    {
        [SerializeField] private GameObject[] _bottomDecors;
        [SerializeField] private GameObject[] _topDecors;
        
        private void Start()
        {
            Randomize();
        }

        public void Randomize()
        {
            foreach (var decor in _bottomDecors)
            {
                decor.SetActive(Random.value < 0.5f);
            }

            foreach (var decor in _topDecors)
            {
                decor.SetActive(Random.value < 0.5f);
            }
        }
    }
}