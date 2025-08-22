using System.Collections.Generic;
using System.Linq;

namespace Game.Core
{
    public static partial class CharacterTurnUseCase
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
        
        public static void ResetPlayerCharactersTurn(IGameContext context)
        {
            var characters = GetPlayerCharacters(context);
            foreach (var character in characters)
            {
                Reset(character);
            }
        }
        
        public static void ResetEnemiesTurn(IGameContext context)
        {
            var enemies = GetEnemyCharacters(context);
            foreach (var character in enemies)
            {
                Reset(character);
            }
        }
        
        public static bool HasAlivePlayerCharacters(IGameContext context)
        {
            var characters = GetPlayerCharacters(context);
            return HealthUseCase.HasAliveEntities(characters);
        }
    }
}