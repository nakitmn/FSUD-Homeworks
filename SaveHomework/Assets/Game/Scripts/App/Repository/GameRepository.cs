using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using ModestTree;
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
            get => PlayerPrefs.GetInt(SAVE_VERSION_KEY, 0);
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
            gameState["DEBUG"] = "change";

            var json = JsonConvert.SerializeObject(gameState);
            
            Version++;

            await UniTask.WhenAll(
                File.WriteAllTextAsync(_filePath, json).AsUniTask(),
                _client.Save(json, Version.ToString())
            );

            return new(true, Version.ToString());
        }

        public async UniTask<IGameRepository.LoadResult> GetState(string version)
        {
            var (success, remoteJson) = await _client.Load(version);

            var remoteState = success
                ? JsonConvert.DeserializeObject<Dictionary<string, string>>(remoteJson) ?? new()
                : null;

            if (int.Parse(version) == Version)
            {
                var latestState = await GetLatestState(remoteState);
                return new(success, version, latestState);
            }

            return new(success, version, remoteState);
        }

        private async UniTask<Dictionary<string, string>> GetLatestState(Dictionary<string, string> remoteState)
        {
            var localSaveJson = await File.ReadAllTextAsync(_filePath);

            if (string.IsNullOrEmpty(localSaveJson))
            {
                return remoteState;
            }

            var localState = JsonConvert.DeserializeObject<Dictionary<string, string>>(localSaveJson);

            if (localState == null)
            {
                return remoteState;
            }

            var remoteSaveTime = long.Parse(remoteState[SAVE_TIME_KEY]);
            var localSaveTime = long.Parse(localState[SAVE_TIME_KEY]);

            if (remoteSaveTime >= localSaveTime)
            {
                Debug.Log("Select Remote State");
                return remoteState;
            }
            
            Debug.Log("Select Local State");
            return  localState;
        }
    }
}