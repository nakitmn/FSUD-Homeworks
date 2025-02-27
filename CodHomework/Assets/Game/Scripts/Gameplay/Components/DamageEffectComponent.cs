using DG.Tweening;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class DamageEffectComponent
    {
        private const int FLASH_COUNTS = 2;

        private readonly SpriteRenderer _spriteRenderer;
        private readonly float _duration;
        private readonly Color _color;
        private readonly Color _defaultColor;

        public DamageEffectComponent(SpriteRenderer spriteRenderer, float duration, Color color)
        {
            _spriteRenderer = spriteRenderer;
            _defaultColor = _spriteRenderer.color;
            _duration = duration;
            _color = color;
        }

        public void Play()
        {
            var stepDuration = _duration / FLASH_COUNTS / 2;

            DOTween.Sequence()
                .AppendCallback(() => _spriteRenderer.color = _defaultColor)
                .Append(
                    _spriteRenderer.DOColor(_color, stepDuration)
                        .SetLink(_spriteRenderer.gameObject)
                )
                .Append(
                    _spriteRenderer.DOColor(_defaultColor, stepDuration)
                        .SetLink(_spriteRenderer.gameObject)
                )
                .SetLoops(FLASH_COUNTS, LoopType.Yoyo);
        }
    }
}