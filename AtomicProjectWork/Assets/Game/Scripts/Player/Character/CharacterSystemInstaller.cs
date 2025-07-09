using System;
using Atomic.Entities;
using UnityEngine;

namespace SampleGame
{
    [Serializable]
    public sealed class CharacterSystemInstaller : IEntityInstaller<IGameContext>
    {
        [SerializeField]
        private SceneEntity _character;

        public void Install(IGameContext context)
        {
            context.AddCharacter(_character);
            context.AddBehaviour<CharacterPointMoveController>();
            context.AddBehaviour<CharacterInteractController>();
            context.AddBehaviour<CharacterUseAbilityController>();
        }
    }
}