using DG.Tweening;
using UnityEngine;

namespace Game.View
{
    public sealed class CharacterView : MonoBehaviour
    {
        [SerializeField] private ProgressBarPro _healthBar;
        [SerializeField] private string _numericPropertyName;
        [SerializeField] private Renderer[] _hitRenderers;
        [SerializeField] private AnimationCurve _animationCurve;
        [SerializeField] private float _hitDuration = 0.3f;
        [SerializeField] private float _minValue;
        [SerializeField] private float _maxValue;
        
        public void SetMaxHealth(int health)
        {
            _healthBar.SetValue(health,health);
        }
        
        public void SetHealth(float healthNormalized)
        {
            _healthBar.Value = healthNormalized;
        }

        public void PlayHit()
        {
            var propertyShaderID = Shader.PropertyToID(_numericPropertyName);
            
            foreach (var renderer in _hitRenderers)
            {
                DOVirtual.Float(0f, 1f, _hitDuration, normalizedTime =>
                {
                    float curveValue = _animationCurve.Evaluate(normalizedTime);
                    float remappedValue = Mathf.Lerp(_minValue, _maxValue, curveValue);

                    var materials = renderer.materials;
                    for (int i = 0; i < materials.Length; i++)
                        if (materials[i] != null)
                            materials[i].SetFloat(propertyShaderID, remappedValue);
                });
            }
        }
    }
}