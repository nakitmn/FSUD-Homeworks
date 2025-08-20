namespace Game.Core
{
    public static class PlayerCharactersUseCase
    {
        public static bool HasAliveCharacters(IGameContext context)
        {
            var characters = CharacterTurnUseCase.GetPlayerCharacters(context);
            return HealthUseCase.HasAliveEntities(characters);
        }
    }
}