using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace SampleGame.App
{
    public sealed class GameSaveLoader
    {
        private readonly IGameRepository _repository;
        private readonly IEnumerable<IGameSerializer> _serializers;

        public GameSaveLoader(IGameRepository repository, IEnumerable<IGameSerializer> serializers)
        {
            _repository = repository;
            _serializers = serializers;
        }

        public async UniTask<IGameRepository.SaveResult> Save()
        {
            var gameState = new Dictionary<string, string>();

            foreach (IGameSerializer serializer in _serializers)
            {
                serializer.Serialize(gameState);
            }

            return await _repository.SetState(gameState);
        }

        public async UniTask<IGameRepository.LoadResult> Load(string versionText)
        {
            var result = await _repository.GetState(versionText);

            foreach (IGameSerializer serializer in _serializers)
            {
                serializer.Deserialize(result.GameState);
            }

            return result;
        }
    }
}