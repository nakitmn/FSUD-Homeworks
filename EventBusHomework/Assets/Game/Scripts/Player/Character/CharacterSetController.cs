using System;
using Atomic.Entities;

namespace SampleGame
{
    public sealed class CharacterSetController : IEnable<IGameContext>
    {
        private readonly CharacterInstaller[] _installers;

        public CharacterSetController(CharacterInstaller[] installers)
        {
            _installers = installers;
        }
        
        public void Enable(IGameContext context)
        {
            foreach (var installer in _installers)
            {
                GameBoardSetUseCase.Set(context, installer.character, installer.position);
            }
        }

        [Serializable]
        public class CharacterInstaller
        {
            public GameEntity character;
            public GameBoardPosition position;
        }
    }
}