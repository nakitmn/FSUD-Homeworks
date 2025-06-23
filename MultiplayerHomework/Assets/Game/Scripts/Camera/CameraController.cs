using Fusion;
using UnityEngine;

namespace Game
{
    public sealed class CameraController : SimulationBehaviour
    {
        [SerializeField] private Transform _follower;
        [SerializeField] private float _speed;

        public override void Render()
        {
            var playerObject = Runner.GetPlayerObject(Runner.LocalPlayer);
            if (playerObject == null)
            {
                return;
            }

            _follower.position = Vector3.Lerp(
                _follower.position,
                playerObject.transform.position,
                _speed * Time.deltaTime
            );
        }
    }
}