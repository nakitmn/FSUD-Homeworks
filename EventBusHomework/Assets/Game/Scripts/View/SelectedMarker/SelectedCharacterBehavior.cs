using Atomic.Elements;
using Atomic.Entities;
using SampleGame;

namespace Game.View
{
    public sealed class SelectedCharacterBehavior : IEnable<IViewContext>, IDisable
    {
        private readonly SelectedMarkerView _markerView;
        private IReactiveVariable<IGameEntity> _selectedCharacter;
        private EntityWorldView _entityWorldView;

        public SelectedCharacterBehavior(SelectedMarkerView markerView)
        {
            _markerView = markerView;
        }

        public void Enable(IViewContext context)
        {
            _selectedCharacter = context.GetSelectedCharacter();
            _entityWorldView = context.GetWorldView();
            _selectedCharacter.Observe(OnSelectedCharacterChanged);
        }

        public void Disable(in IEntity entity)
        {
            _selectedCharacter.Unsubscribe(OnSelectedCharacterChanged);
        }

        private void OnSelectedCharacterChanged(IGameEntity entity)
        {
            if (entity == null)
            {
                _markerView.SetActive(false);
                _markerView.SetTarget(null);
                return;
            }

            var view = _entityWorldView.GetView(entity);
            _markerView.SetActive(true);
            _markerView.SetTarget(view.transform);
        }
    }
}