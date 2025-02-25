using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Newtonsoft.Json;
using UnityEngine;

namespace SampleGame.App
{
    public sealed class GameRepository : IGameRepository, IComparer<Dictionary<string,string>>
    {
        private static readonly DateTime originTime = new(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        private const string SAVE_TIME_KEY = "SaveTime";
        private const string SAVE_VERSION_KEY = "Version";

        private readonly GameServer _server;
        private readonly FileRepository _fileRepository;

        private int Version
        {
            get => PlayerPrefs.GetInt(SAVE_VERSION_KEY, 0);
            set => PlayerPrefs.SetInt(SAVE_VERSION_KEY, value);
        }

        public GameRepository(GameServer server, FileRepository fileRepository)
        {
            _server = server;
            _fileRepository = fileRepository;
        }

        public async UniTask<IGameRepository.SaveResult> SetState(Dictionary<string, string> gameState)
        {
            var time = DateTime.Now.ToUniversalTime() - originTime;
            var saveTime = time.TotalSeconds.ToString("F0");
            gameState[SAVE_TIME_KEY] = saveTime;

            var json = JsonConvert.SerializeObject(gameState);
            var encryptedJson = Encryptor.Encrypt(json);

            Version++;

            _fileRepository.SetContent(Version, encryptedJson);
            
            await _server.Save(encryptedJson, Version.ToString());

            return new(true, Version.ToString());
        }

        public async UniTask<IGameRepository.LoadResult> GetState(string version)
        {
            var (success, encryptedRemoteJson) = await _server.Load(version);
            var remoteJson = Encryptor.Decrypt(encryptedRemoteJson);
            
            var remoteState = success
                ? JsonConvert.DeserializeObject<Dictionary<string, string>>(remoteJson) ?? new()
                : null;

            var latestState = GetLatestState(int.Parse(version), remoteState);
            return new(success, version, latestState);
        }

        private Dictionary<string, string> GetLatestState(int version,
            Dictionary<string, string> remoteState)
        {
            if (_fileRepository.TryGetContent(version, out var encryptedLocalJson) == false)
            {
                return remoteState;
            }

            if (string.IsNullOrEmpty(encryptedLocalJson))
            {
                return remoteState;
            }

            var localJson = Encryptor.Decrypt(encryptedLocalJson);
            var localState = JsonConvert.DeserializeObject<Dictionary<string, string>>(localJson);

            if (Compare(remoteState, localState) >= 0)
            {
                Debug.Log("Select Remote State");
                return remoteState;
            }
            
            Debug.Log("Select Local State");
            return localState;
        }

        public int Compare(Dictionary<string, string> firstState, Dictionary<string, string> secondState)
        {
            if (firstState == null)
            {
                return -1;
            }
            
            if (secondState == null)
            {
                return 1;
            }
            
            var firstSaveTime = long.Parse(firstState[SAVE_TIME_KEY]);
            var secondSaveTime = long.Parse(secondState[SAVE_TIME_KEY]);
            
            return (int) (firstSaveTime - secondSaveTime);
        }
    }
}