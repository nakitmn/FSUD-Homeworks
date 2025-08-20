using DG.Tweening;
using UnityEngine;

namespace SampleGame
{
    public sealed class GameBoardCellView : MonoBehaviour
    {
        [SerializeField] private Renderer _renderer;
        [SerializeField] private float _moveHighlightHeight = -0.2f;
        [SerializeField] private float _moveHighlightDuration = 0.3f;

        public void SetMaterial(Material material)
        {
            _renderer.material = material;
        }

        public void PlayMoveEnabled()
        {
            transform.DOLocalMoveY(_moveHighlightHeight, _moveHighlightDuration);
        }
        
        public void PlayMoveDisabled()
        {
            transform.DOLocalMoveY(0f, _moveHighlightDuration);
        }
    }
}