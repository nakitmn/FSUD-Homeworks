using Leopotam.EcsLite;
using SampleGame.PurchaseUnit;
using UnityEngine;

namespace SampleGame
{
    public sealed class UnitCardPresenter : MonoBehaviour
    {
        [SerializeField] private UnitCardView _view;

        private UnitCardConfig _config;
        private EcsWorld _ecsWorld;
        private PlayerData _playerData;

        private void OnEnable()
        {
            _view.OnClicked += OnClicked;
        }

        private void OnDisable()
        {
            _view.OnClicked -= OnClicked;
        }

        private void LateUpdate()
        {
            var progress = Mathf.Clamp01((float) _playerData.money / _config.Price);
            _view.SetProgress(progress);
            _view.SetProgressCaption(progress < 1f
                ? $"{_playerData.money}/{_config.Price}"
                : "Click 2 Purchase!");
        }

        public void Construct(UnitCardConfig config)
        {
            _config = config;
            _ecsWorld = EcsAdmin.Systems.GetWorld();
            _playerData = _ecsWorld.GetSingleton<PlayerData>();

            _view.SetIcon(_config.Icon);
            _view.SetName(_config.Name);
        }

        private void OnClicked()
        {
            _ecsWorld.GetEvent<PurchaseUnitRequest>().Fire(new PurchaseUnitRequest() {config = _config});
        }
    }
}