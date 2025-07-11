using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;
using UnityEngine.Serialization;

namespace SampleGame
{
    public sealed class GameContextInstaller : SceneEntityInstaller<IGameContext>
    {
        [SerializeField] private Transform _worldTransform;
        [SerializeField] private Transform _poolContainer;
        [SerializeField] private InputMap _inputMap;
        [SerializeField] private CharacterSystemInstaller _characterInstaller;
        [SerializeField] private CameraSystemInstaller _cameraInstaller;
        [SerializeField] private GameObject _moveClickEffectPrefab;

        protected override void Install(IGameContext context)
        {
            context.AddWorldTransform(_worldTransform);
            context.AddEntityPool(new GenericSceneEntityPool(_poolContainer));
            context.AddPrefabPool(new GenericPrefabPool(_poolContainer));
            context.AddGroundPlane(new Plane(Vector3.up, Vector3.zero));
            context.AddInputMap(_inputMap);
            
            context.AddPlayMoveClickAction(new BaseAction<Vector3>(point =>
                context.GetPrefabPool().Rent(_moveClickEffectPrefab, point, _moveClickEffectPrefab.transform.rotation)));
            context.AddPlayAbilityClickAction(new BaseAction<GameObject, Vector3>((prefab,point) =>
                context.GetPrefabPool().Rent(prefab, point, prefab.transform.rotation)));

            _characterInstaller.Install(context);
            _cameraInstaller.Install(context);
        }
    }
}