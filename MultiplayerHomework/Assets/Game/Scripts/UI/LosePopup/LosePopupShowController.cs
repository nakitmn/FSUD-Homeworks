using System;
using UnityEngine;

namespace Game
{
    public sealed class LosePopupShowController : MonoBehaviour
    {
        [SerializeField] private GameCycle _gameCycle;
        [SerializeField] private GameObject _losePopup;

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