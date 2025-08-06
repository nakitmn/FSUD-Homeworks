using System.Linq;
using UnityEngine;

namespace SampleGame
{
    public static class EnemyUseCase
    {
        public static bool HasAliveEnemies(IGameContext context)
        {
            var enemies = CharacterTurnUseCase.GetEnemyCharacters(context);
            return HealthUseCase.HasAliveEntities(enemies);
        }

        public static void SelectRandomTarget(IGameContext context, IGameEntity entity)
        {
            var characters = CharacterTurnUseCase.GetPlayerCharacters(context);
            
            var aliveCharacters = characters.Where(x => HealthUseCase.Exists(x)).ToArray();
            entity.GetTarget().Value = aliveCharacters.Length > 0
                ? aliveCharacters[Random.Range(0, aliveCharacters.Length)]
                : null;
        }
    }
}