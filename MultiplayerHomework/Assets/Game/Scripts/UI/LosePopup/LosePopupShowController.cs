using System;
using UnityEngine;
using Zenject;

namespace Game
{
    public sealed class LosePopupShowController : MonoBehaviour
    {
        [SerializeField] private GameObject _losePopup;
        
        private GameCycle _gameCycle;

        [Inject]
        public void Construct( GameCycle gameCycle )
        {
            _gameCycle = gameCycle;
        }
        
        private void OnEnable()
        {
            _gameCycle.OnStateChanged += OnStateChanged;
        }

        private void OnDisable()
        {
            _gameCycle.OnStateChanged -= OnStateChanged;
        }

        private void OnStateChanged(GameCycle.State state)
        {
            if (state == GameCycle.State.Lose)
            {
                _losePopup.SetActive(true);
            }
        }
    }
}