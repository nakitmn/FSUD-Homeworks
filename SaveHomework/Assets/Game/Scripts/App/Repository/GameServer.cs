using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace SampleGame.App
{
    public sealed class GameServer
    {
        private readonly string _uri;

        public GameServer(string uri)
        {
            _uri = uri;
        }

        public async UniTask<bool> Save(string json, string version)
        {
            var request = UnityWebRequest.Put($"{_uri}/save?version={version}", json);
            await request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError(request.error);
            }
            else
            {
                Debug.Log(request.downloadHandler.text);
            }

            return request.result == UnityWebRequest.Result.Success;
        }

        public async UniTask<(bool, string)> Load(string version)
        {
            var request = UnityWebRequest.Get($"{_uri}/load?version={version}");
            await request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError(request.error);
                return (false, null);
            }
            
            Debug.Log(request.downloadHandler.text);

            var json = request.downloadHandler.text;
            return string.IsNullOrEmpty(json)
                ? (false, null)
                : (true, json);
        }
    }
}