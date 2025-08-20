using DG.Tweening;
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

        public void PlayMoveEnabled()
        {
            transform.DOLocalMoveY(-0.1f, 0.3f);
        }
        
        public void PlayMoveDisabled()
        {
            transform.DOLocalMoveY(0f, 0.3f);
        }
    }
}