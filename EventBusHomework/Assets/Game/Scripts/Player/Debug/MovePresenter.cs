using Sirenix.OdinInspector;
using UnityEngine;

namespace SampleGame
{
    public sealed class MovePresenter : MonoBehaviour
    {
        [SerializeField]
        private GameEntity _source;
        
        [Button]
        public void Move(int x, int y)
        {
            var command = new MoveCommand(_source,x,y);
            command.Execute(GameContext.Instance);
        }
    }
}