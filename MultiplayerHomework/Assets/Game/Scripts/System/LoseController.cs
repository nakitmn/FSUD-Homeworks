using Fusion;
using UnityEngine;

namespace Game
{
    public sealed class LoseController : NetworkBehaviour
    {
        [SerializeField] private GameCycle _gameCycle;
        [SerializeField] private HealthComponent _portal;
        
        public override void FixedUpdateNetwork()
        {
            if (_gameCycle.CurrentState != GameCycle.State.Running)
            {
                return;
            }

            if (HasDiedPlayer() || _portal.Exists() == false)
            {
                _gameCycle.CurrentState = GameCycle.State.Lose;
            }
        }

        private bool HasDiedPlayer()
        {
            foreach (var player in Runner.ActivePlayers)
            {
                var networkObject = Runner.GetPlayerObject(player);
                var healthComponent = networkObject.GetComponent<HealthComponent>();
                if (healthComponent.Exists() == false)
                {
                    return true;
                }
            }

            return false;
        }
    }
}