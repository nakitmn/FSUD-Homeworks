using System;
using Atomic.Entities;
using SampleGame;
using UnityEngine;

namespace Game.View
{
    [Serializable]
    public sealed class GameBoardInstaller : IEntityInstaller<IViewContext>
    {
        [SerializeField] private GameBoardView _gameBoardView;

        public void Install(IViewContext entity)
        {
            entity.AddGameBoardView(_gameBoardView);
            entity.AddBehaviour<GameBoardPresenter>();
        }
    }
}