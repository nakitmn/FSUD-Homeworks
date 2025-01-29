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

        private readonly GameClient _client;
        private readonly string _filePath;

        public GameRepository(GameClient client, string filePath)
        {
            _client = client;
            _filePath = filePath;
        }

        public async UniTask SetState(Dictionary<string, string> gameState)
        {
            var time = DateTime.Now.ToUniversalTime() - originTime;
            var saveTime = time.TotalSeconds.ToString("F0");
            gameState[SAVE_TIME_KEY] = saveTime;

            var json = JsonConvert.SerializeObject(gameState);

            await UniTask.WhenAll(
                File.WriteAllTextAsync(_filePath, json).AsUniTask(),
                _client.Save(json)
            );
        }

        public async UniTask<Dictionary<string, string>> GetState()
        {
            //Get local state:
            long localSaveTime = -1;
            Dictionary<string, string> localState;

            if (File.Exists(_filePath))
            {
                string json = await File.ReadAllTextAsync(_filePath);
                if (json == null)
                {
                    localState = new Dictionary<string, string>();
                }
                else
                {
                    localState = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
                    if (localState == null)
                    {
                        localState = new Dictionary<string, string>();
                    }
                    else
                    {
                        string saveTimeString = localState[SAVE_TIME_KEY];
                        localSaveTime = long.Parse(saveTimeString);
                    }
                }
            }
            else
            {
                localState = new Dictionary<string, string>();
            }

            //Get remote state:
            long remoteSaveTime = -1;
            Dictionary<string, string> remoteState;

            var (success, remoteJson) = await _client.Load();
            if (success)
            {
                remoteState = JsonConvert.DeserializeObject<Dictionary<string, string>>(remoteJson);
                if (remoteState != null)
                {
                    remoteSaveTime = long.Parse(remoteState[SAVE_TIME_KEY]);
                }
                else
                {
                    remoteState = new Dictionary<string, string>();
                }
            }
            else
            {
                remoteState = new Dictionary<string, string>();
            }


            //Compare:
            if (localSaveTime >= remoteSaveTime)
            {
                Debug.Log("Select local state");
                return localState;
            }
            else
            {
                Debug.Log("Select remote state");
                return remoteState;
            }
        }
    }
}