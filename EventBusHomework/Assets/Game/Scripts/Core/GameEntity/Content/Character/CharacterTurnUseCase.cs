using System.Collections.Generic;
using System.Linq;

namespace SampleGame
{
    public static class CharacterTurnUseCase
    {
        public static IReadOnlyList<IGameEntity> GetPlayerCharacters(IGameContext context)
        {
            var world = context.GetEntityWorld();
            return world.GetAllWithTag(GameEntityAPI.Character).Select(x=>x as IGameEntity).ToList();
        }
        
        public static IReadOnlyList<IGameEntity> GetEnemyCharacters(IGameContext context)
        {
            var world = context.GetEntityWorld();
            return world.GetAllWithTag(GameEntityAPI.Enemy).Select(x=>x as IGameEntity).ToList();
        }
        
        public static bool CanAttackInTurn(IGameEntity entity)
        {
            return entity.GetCurrentAttacksCount().Value < entity.GetMaxAttacksPerTurn().Value;
        }

        public static bool CanMoveInTurn(IGameEntity entity)
        {
            return entity.GetCurrentMovesCount().Value < entity.GetMaxMovesPerTurn().Value;
        }

        public static void ResetCharacters(IGameContext context)
        {
            var characters = GetPlayerCharacters(context);
            foreach (var character in characters)
            {
                Reset(character);
            }
        }
        
        public static void ResetEnemies(IGameContext context)
        {
            var enemies = GetEnemyCharacters(context);
            foreach (var character in enemies)
            {
                Reset(character);
            }
        }
        
        public static void Reset(IGameEntity entity)
        {
            entity.GetCurrentMovesCount().Value = 0;
            entity.GetCurrentAttacksCount().Value = 0;
        }
    }
}