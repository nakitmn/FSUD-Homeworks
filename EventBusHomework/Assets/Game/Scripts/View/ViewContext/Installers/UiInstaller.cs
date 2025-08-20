using System;
using Atomic.Entities;
using SampleGame;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.View
{
    [Serializable]
    public sealed class UiInstaller : IEntityInstaller<IViewContext>
    {
        [SerializeField] private TurnView _turnView;
        [SerializeField] private TMP_Text _turnEventsText;
        [SerializeField] private TMP_Text _selectedCharacterInfoText;
        [SerializeField] private TMP_Text _gameStateText;
        [SerializeField] private TMP_Text _currentTurnText;
        [SerializeField] private Button _endTurnButton;
        
        public void Install(IViewContext entity)
        {
            entity.AddTurnView(_turnView);
            entity.AddEndTurnButton(_endTurnButton);
            
            entity.AddBehaviour(new TurnEventsPresenter(_turnEventsText));
            entity.AddBehaviour(new SelectedCharacterStatsPresenter(_selectedCharacterInfoText));
            entity.AddBehaviour(new GameStatePresenter(_gameStateText));
            entity.AddBehaviour(new CurrentTurnPresenter(_currentTurnText));
            entity.AddBehaviour(new EndTurnButtonPresenter(_endTurnButton));
        }
    }
}