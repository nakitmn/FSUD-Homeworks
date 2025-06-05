using System;
using Fusion;
using UnityEngine;

namespace Game
{
    public sealed class InputReceiver : NetworkBehaviour
    {
        public event Action<Vector3, float> OnMove;
        public event Action OnMine;
        public event Action OnTurret;

        [Networked] private NetworkButtons PreviousButtons { get; set; }

        public InputData InputData { get; private set; }
        
        public override void FixedUpdateNetwork()
        {
            if (GetInput(out InputData input) == false)
            {
                InputData = default;
                return;
            }
            
            var deltaTime = Runner.DeltaTime;
            
            OnMove?.Invoke(input.moveDirection, deltaTime);
            ProcessButtons(ref input);
            
            PreviousButtons = input.buttons;
            InputData = input;
        }

        private void ProcessButtons(ref InputData input)
        {
            if (input.buttons.WasPressed(PreviousButtons, PlayerKeys.Mine))
            {
                OnMine?.Invoke();
            }
            
            if (input.buttons.WasPressed(PreviousButtons, PlayerKeys.Turret))
            {
                OnTurret?.Invoke();
            }
        }
    }
}