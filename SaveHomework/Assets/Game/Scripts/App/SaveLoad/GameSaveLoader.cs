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

        public async UniTask Save()
        {
            var gameState = new Dictionary<string, string>();
            
            foreach (IGameSerializer serializer in _serializers)
            {
                serializer.Serialize(gameState);
            }

            await _repository.SetState(gameState);
        }

        public async UniTask Load(string versionText)
        {
            var gameState = await _repository.GetState();

            foreach (IGameSerializer serializer in _serializers)
            {
                serializer.Deserialize(gameState);
            }
        }
    }
}