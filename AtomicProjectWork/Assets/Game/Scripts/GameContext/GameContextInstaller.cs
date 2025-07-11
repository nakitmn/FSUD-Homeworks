using Atomic.Entities;
using UnityEngine;

namespace SampleGame
{
    public sealed class GameContextInstaller : SceneEntityInstaller<IGameContext>
    {
        [SerializeField] private Transform _worldTransform;
        [SerializeField] private Transform _poolContainer;
        [SerializeField] private InputMap _inputMap;
        [SerializeField] private CharacterSystemInstaller _characterInstaller;
        [SerializeField] private CameraSystemInstaller _cameraInstaller;

        protected override void Install(IGameContext context)
        {
            context.AddWorldTransform(_worldTransform);
            context.AddEntityPool(new GenericSceneEntityPool(_poolContainer));
            context.AddPrefabPool(new GenericPrefabPool(_poolContainer));
            context.AddGroundPlane(new Plane(Vector3.up, Vector3.zero));
            context.AddInputMap(_inputMap);

            _characterInstaller.Install(context);
            _cameraInstaller.Install(context);
        }
    }
}