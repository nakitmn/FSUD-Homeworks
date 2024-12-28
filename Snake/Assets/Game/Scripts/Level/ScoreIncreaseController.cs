using Modules;

namespace Game.Gameplay
{
    public sealed class ScoreIncreaseController : ICoinCollectedListener
    {
        private readonly IScore _score;

        public ScoreIncreaseController(IScore score)
        {
            _score = score;
        }

        public void OnCollected(ICoin coin)
        {
            _score.Add(coin.Score);
        }
    }
}