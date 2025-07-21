using System;

namespace SampleGame
{
    public static class PlayerCharactersUseCase
    {
        public static bool HasAliveCharacters(IGameContext context)
        {
            var characters = context.GetCharacters();
            return Array.Exists(characters, character => HealthUseCase.Exists(character));
        }
    }
}