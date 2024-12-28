using System;
using UnityEngine;

namespace Game.Views
{
    public interface IPlanetPopupPresenter
    {
        event Action OnStateChanged;
        event Action OnIncomeChanged;
        event Action OnPopulationChanged;
        event Action OnUpgraded;

        Sprite PlanetIcon { get; }
        string PlanetName { get; }
        string Population { get; }
        string Level { get; }
        string Income { get; }
        string Price { get; }
        bool CanUpgrade { get; }
        bool IsMaxLevel { get; }
        string MaxLevel { get; }

        void OnUpgradeClicked();
        void Enable();
        void Disable();
    }
}