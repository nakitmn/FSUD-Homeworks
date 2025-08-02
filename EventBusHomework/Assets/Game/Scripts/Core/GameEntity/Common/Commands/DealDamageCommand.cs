namespace SampleGame
{
    public struct DealDamageCommand : ICommand
    {
        private readonly IGameEntity _target;
        private readonly int _damage;

        public DealDamageCommand(IGameEntity target, int damage)
        {
            _target = target;
            _damage = damage;
        }

        public bool Execute(IGameContext gameContext)
        {
            if (HealthUseCase.DealDamage(_target,_damage))
            {
                gameContext.GetEventBus().InvokeDamaged(_target, _damage);
                //gameContext.GetAnimationQueue().Enqueue(new DealDamageAnimationCommand(_target.GetTransform()));
                return true;
            }

            return false;
        }
    }
}