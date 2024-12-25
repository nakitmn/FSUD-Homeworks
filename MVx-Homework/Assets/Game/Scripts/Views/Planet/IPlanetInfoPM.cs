using System;

namespace Game.Scripts.Views.Planet
{
    public interface IPlanetInfoPM
    {
        event Action OnStateChanged;

        string PlanetName { get; }
        string Population { get; }
        string Level { get; }
        string Income { get; }
        string Price { get; }
        bool CanUpgrade { get; }

        void OnUpgradeClicked();
        void Enable();
        void Disable();
    }
}