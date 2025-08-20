using Atomic.Elements;
using Atomic.Entities;
using Game.Core;

namespace Game.View
{
    public sealed class SelectedMarkerPresenter : IEnable<IViewContext>, IDisable
    {
        private readonly SelectedMarkerView _markerView;
        
        private IReactiveVariable<IGameEntity> _selectedCharacter;
        private EntityWorldView _entityWorldView;

        public SelectedMarkerPresenter(SelectedMarkerView markerView)
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
                _markerView.Hide();
                return;
            }

            var view = _entityWorldView.GetView(entity);
            _markerView.Show(view.transform);
        }
    }
}