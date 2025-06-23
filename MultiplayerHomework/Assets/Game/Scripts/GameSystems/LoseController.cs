using Fusion;
using Zenject;

namespace Game
{
    public sealed class LoseController : NetworkBehaviour
    {
        private GameCycle _gameCycle;
        private Portal _portal;

        [Inject]
        public void Construct(GameCycle gameCycle, Portal portal)
        {
            _portal = portal;
            _gameCycle = gameCycle;
        }

        public override void FixedUpdateNetwork()
        {
            if (_gameCycle.CurrentState != GameCycle.State.Running)
            {
                return;
            }

            if (HasDiedPlayer() || _portal.IsDead)
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