using System;
using System.Collections.Generic;
using System.IO;
using Cysharp.Threading.Tasks;
using Newtonsoft.Json;
using UnityEngine;

namespace SampleGame.App
{
    public sealed class GameRepository : IGameRepository
    {
        private static readonly DateTime originTime = new(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        private const string SAVE_TIME_KEY = "SaveTime";
        private const string SAVE_VERSION_KEY = "Version";

        private readonly GameClient _client;
        private readonly string _filePath;
        
        private int Version
        {
            get => PlayerPrefs.GetInt(SAVE_VERSION_KEY, 1);
            set => PlayerPrefs.SetInt(SAVE_VERSION_KEY, value);
        }

        public GameRepository(GameClient client, string filePath)
        {
            _client = client;
            _filePath = filePath;
        }

        public async UniTask<IGameRepository.SaveResult> SetState(Dictionary<string, string> gameState)
        {
            var time = DateTime.Now.ToUniversalTime() - originTime;
            var saveTime = time.TotalSeconds.ToString("F0");
            gameState[SAVE_TIME_KEY] = saveTime;

            var json = JsonConvert.SerializeObject(gameState);
            var saveVersion = Version.ToString();

            await UniTask.WhenAll(
                File.WriteAllTextAsync(_filePath, json).AsUniTask(),
                _client.Save(json, saveVersion)
            );

            Version++;
            
            return new(true, saveVersion);
        }

        public async UniTask<IGameRepository.LoadResult> GetState(string version)
        {
            Dictionary<string, string> remoteState;

            var (success, remoteJson) = await _client.Load(version);

            if (success)
            {
                remoteState = JsonConvert.DeserializeObject<Dictionary<string, string>>(remoteJson);

                if (remoteState == null)
                {
                    remoteState = new Dictionary<string, string>();
                }
            }
            else
            {
                remoteState = new Dictionary<string, string>();
            }

            return new(success, version, remoteState);
        }
    }
}