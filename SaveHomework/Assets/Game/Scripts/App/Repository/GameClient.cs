using Cysharp.Threading.Tasks;
using UnityEngine.Networking;

namespace SampleGame.App
{
    public sealed class GameClient
    {
        private readonly string _uri;

        public GameClient(string uri)
        {
            _uri = uri;
        }

        public async UniTask<bool> Save(string json)
        {
            var request = UnityWebRequest.Put($"{_uri}/save", json);
            await request.SendWebRequest();
            return request.result == UnityWebRequest.Result.Success;
        }

        public async UniTask<(bool, string)> Load()
        {
            var request = UnityWebRequest.Get($"{_uri}/load");
            await request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
            {
                return (false, null);
            }

            var json = request.downloadHandler.text;
            return string.IsNullOrEmpty(json)
                ? (false, null)
                : (true, json);
        }
    }
}