using System;
using Atomic.Entities;

namespace SampleGame
{
    public sealed class CharacterSetController : IEnable<IGameContext>
    {
        [Serializable]
        public class CharacterInstaller
        {
            public ScriptableEntityInstaller character;
            public GameBoardPosition position;
        }

        private readonly CharacterInstaller[] _installers;

        public CharacterSetController(CharacterInstaller[] installers)
        {
            _installers = installers;
        }

        public void Enable(IGameContext context)
        {
            foreach (var installer in _installers)
            {
                SpawnEntityUseCase.Spawn(context, installer.character, installer.position);
            }
        }
    }
}