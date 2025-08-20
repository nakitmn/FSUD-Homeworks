using Cysharp.Threading.Tasks;

namespace Game.View
{
    public readonly struct UpdateHealthAnimationCommand : IAnimationCommand
    {
        private readonly CharacterView _characterView;
        private readonly float _health;

        public UpdateHealthAnimationCommand(CharacterView characterView, float health)
        {
            _characterView = characterView;
            _health = health;
        }

        public async UniTask Execute()
        {
            _characterView.SetHealth(_health);
            await UniTask.CompletedTask;
        }
    }
}