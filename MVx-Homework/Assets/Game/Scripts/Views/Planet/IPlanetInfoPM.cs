using System;
using UnityEngine;

namespace Game.Scripts.Views.Planet
{
    public interface IPlanetInfoPM
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

        void OnUpgradeClicked();
        void Enable();
        void Disable();
    }
}