using UnityEngine;

namespace SampleGame
{
    public sealed class GameBoardCellView : MonoBehaviour
    {
        [SerializeField] private Renderer _renderer;

        public void SetMaterial(Material material)
        {
            _renderer.material = material;
        }
    }
}