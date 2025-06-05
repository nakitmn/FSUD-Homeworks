using Fusion;
using UnityEngine;

namespace Game
{
    public sealed class PlayerJoinController : MonoBehaviour
    {
        [SerializeField] private NetworkEvents _networkEvents;
        [SerializeField] private SpawnPointService _pointService;
        [SerializeField] private GameObject _characterPrefab;

        private void OnEnable()
        {
            _networkEvents.PlayerJoined.AddListener(OnPlayerJoined);
        }

        private void OnDisable()
        {
            _networkEvents.PlayerJoined.RemoveListener(OnPlayerJoined);
        }

        private void OnPlayerJoined(NetworkRunner runner, PlayerRef player)
        {
            if (runner.IsServer == false)
            {
                return;
            }

            var spawnPoint = _pointService.GetSpawnPoint(player.AsIndex - 1);
            var character = runner.Spawn(_characterPrefab, spawnPoint.position, spawnPoint.rotation, player);
            runner.SetPlayerObject(player, character);
        }
    }
}