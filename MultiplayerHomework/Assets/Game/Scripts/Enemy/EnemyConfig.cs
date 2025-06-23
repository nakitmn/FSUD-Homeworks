using UnityEngine;

namespace Game
{
    [CreateAssetMenu(menuName = "Game/Enemy",order = 0)]
    public sealed class EnemyConfig : ScriptableObject
    {
        [SerializeField] private int _damage = 1;
        [SerializeField] private float _playerDamageCooldown = 1f;
        [SerializeField] private Vector2Int _reward;

        public int Damage => _damage;
        public float PlayerDamageCooldown => _playerDamageCooldown;
        public Vector2Int Reward => _reward;
    }
}