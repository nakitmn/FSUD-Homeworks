using Zenject;

namespace Game.Gameplay
{
    public sealed class InputInstaller : Installer<InputInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<PlayerInput>()
                .AsSingle();
        }
    }
}