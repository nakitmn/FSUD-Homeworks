using Atomic.Entities;
using UnityEngine;

namespace SampleGame
{
    public sealed class CharacterInteractController : IInit<IGameContext>, IUpdate
    {
        private IEntity _character;
        
        public void Init(IGameContext context)
        {
            _character = context.GetCharacter();
        }

        public void OnUpdate(in IEntity entity, in float deltaTime)
        {
            if (Input.GetKeyDown(KeyCode.E)) 
                InteractUseCase.InteractAsCharacter(_character);
        }
    }
}