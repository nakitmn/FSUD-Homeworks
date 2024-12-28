using Modules;
using SnakeGame;
using Zenject;

namespace Level_Module
{
    public sealed class LevelInstaller : Installer<int, LevelInstaller>
    {
        [Inject] private int _levelsCount;

        public override void InstallBindings()
        {
            Container.Bind<IWorldBounds>()
                .FromComponentInHierarchy()
                .AsSingle();

            Container.BindInterfacesTo<Difficulty>()
                .AsSingle()
                .WithArguments(_levelsCount);

            Container.BindInterfacesTo<Score>()
                .AsSingle();

            Container.BindInterfacesAndSelfTo<GameCycle>()
                .AsSingle();

            Container.BindInterfacesTo<ScoreIncreaseController>()
                .AsSingle();

            Container.BindInterfacesTo<LoseGameController>()
                .AsSingle();

            Container.BindInterfacesTo<LevelUpController>()
                .AsSingle();
        }
    }
}