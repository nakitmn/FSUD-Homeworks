using System;
using SampleGame.Gameplay;

namespace SampleGame.App
{
    public sealed class CountdownSerializer : EntityComponentSerializer<CountdownSerializer.Data, Countdown>
    {
        protected override Data CreateData(Countdown countdown)
        {
            return new() {Current = countdown.Current};
        }

        protected override void ApplyData(Countdown countdown, Data data)
        {
            countdown.Current = data.Current;
        }
        
        [Serializable]
        public struct Data
        {
            public float Current;
        }
    }
}