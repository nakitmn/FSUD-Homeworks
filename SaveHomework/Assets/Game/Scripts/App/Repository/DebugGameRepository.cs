using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Newtonsoft.Json;

namespace SampleGame.App
{
    public sealed class DebugGameRepository : IGameRepository
    {
        private const int VERSION = 1;
        private readonly FileRepository _fileRepository;

        public DebugGameRepository(FileRepository fileRepository)
        {
            _fileRepository = fileRepository;
        }

        public UniTask<IGameRepository.SaveResult> SetState(Dictionary<string, string> gameState)
        {
            var json = JsonConvert.SerializeObject(gameState);
            _fileRepository.SetContent(VERSION, json);
            return UniTask.FromResult(new IGameRepository.SaveResult(true, VERSION.ToString()));
        }

        public UniTask<IGameRepository.LoadResult> GetState(string version)
        {
            if (_fileRepository.TryGetContent(VERSION, out var localSaveJson) == false)
            {
                return UniTask.FromResult(new IGameRepository.LoadResult(false, VERSION.ToString(), null));
            }

            if (string.IsNullOrEmpty(localSaveJson))
            {
                return UniTask.FromResult(new IGameRepository.LoadResult(false, VERSION.ToString(), null));
            }

            var localState = JsonConvert.DeserializeObject<Dictionary<string, string>>(localSaveJson) 
                             ?? new Dictionary<string, string>();
            return UniTask.FromResult(new IGameRepository.LoadResult(true, VERSION.ToString(), localState));
        }
    }
}