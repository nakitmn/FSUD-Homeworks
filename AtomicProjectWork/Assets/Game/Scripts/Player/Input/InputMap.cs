using UnityEngine;

namespace SampleGame
{
    [CreateAssetMenu(
        fileName = "InputMap",
        menuName = "SampleGame/New InputMap"
    )]
    public sealed class InputMap : ScriptableObject
    {
        [field: SerializeField]
        public int MoveMouseButton { get; private set; } = 0;
        
        [field: SerializeField]
        public int UseAbilityMouseButton { get; private set; } = 1;
        
        [field: SerializeField]
        public KeyCode[] Abilities { get; private set; }
    }
}