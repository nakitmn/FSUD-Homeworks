namespace SampleGame
{
    public static class CharacterTurnUseCase
    {
        public static bool CanAttackInTurn(in IGameEntity entity)
        {
            return entity.GetCurrentAttacksCount().Value < entity.GetMaxAttacksPerTurn().Value;
        }

        public static bool CanMoveInTurn(in IGameEntity entity)
        {
            return entity.GetCurrentMovesCount().Value < entity.GetMaxMovesPerTurn().Value;
        }

        public static void ResetCharacters(in IGameContext context)
        {
            var characters = context.GetCharacters();
            foreach (var character in characters)
            {
                Reset(character);
            }
        }
        
        public static void Reset(in IGameEntity entity)
        {
            entity.GetCurrentMovesCount().Value = 0;
            entity.GetCurrentAttacksCount().Value = 0;
        }
    }
}