using Atomic.Entities;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace SampleGame
{
    public readonly struct SpawnAnimationCommand : IAnimationCommand
    {
        private readonly EntityWorldView _worldView;
        private readonly IGameEntity _entity;
        private readonly Vector3 _position;

        public SpawnAnimationCommand(EntityWorldView worldView, IGameEntity entity, Vector3 position)
        {
            _worldView = worldView;
            _entity = entity;
            _position = position;
        }

        public async UniTask Execute()
        {
            _worldView.SpawnView(_entity);
            var view = _worldView.GetView(_entity);
            var transform = view.transform;
            transform.position = _position;
            
            await transform.DOScale(Vector3.one, 0.5f)
                .ChangeStartValue(Vector3.zero)
                .SetLink(transform.gameObject)
                .AsyncWaitForCompletion();
        }
    }
}