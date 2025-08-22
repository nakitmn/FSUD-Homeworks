namespace Game.Core
{
    public static partial class CharacterTurnUseCase
    {
        public static bool CanAttackInTurn(IGameEntity entity)
        {
            return entity.GetCurrentAttacksCount().Value < entity.GetMaxAttacksPerTurn().Value;
        }

        public static bool CanMoveInTurn(IGameEntity entity)
        {
            return entity.GetCurrentMovesCount().Value < entity.GetMaxMovesPerTurn().Value;
        }
        
        public static void Reset(IGameEntity entity)
        {
            entity.GetCurrentMovesCount().Value = 0;
            entity.GetCurrentAttacksCount().Value = 0;
        }
    }
}