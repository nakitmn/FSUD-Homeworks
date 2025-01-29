using System.IO;
using UnityEngine;
using Zenject;

namespace SampleGame.App
{
    [CreateAssetMenu(
        fileName = "RepositoryInstaller",
        menuName = "Zenject/App/New RepositoryInstaller"
    )]
    public sealed class RepositoryInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private string _fileName = "GameState.txt";
        [SerializeField] private string _uri = "http://127.0.0.1:8888";

        public override void InstallBindings()
        {
            var filePath = Path.Combine(Application.streamingAssetsPath, _fileName);

            Container.Bind<GameClient>().AsSingle().WithArguments(_uri);
            Container.BindInterfacesTo<GameRepository>().AsSingle().WithArguments(filePath);
        }
    }
}