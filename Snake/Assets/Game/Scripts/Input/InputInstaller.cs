using Zenject;

namespace Input_Module
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