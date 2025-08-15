using UnityEngine;

namespace Game.View
{
    public sealed class CharacterView : MonoBehaviour
    {
        [SerializeField] private ProgressBarPro _healthBar;

        public void SetMaxHealth(int health)
        {
            _healthBar.SetValue(health,health);
        }
        
        public void SetHealth(float healthNormalized)
        {
            _healthBar.Value = healthNormalized;
        }
    }
}