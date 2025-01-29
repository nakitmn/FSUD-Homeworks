using SampleGame.Gameplay;

namespace SampleGame.App
{
    public sealed class CountdownSerializer : EntityComponentSerializer<CountdownData, Countdown>
    {
        protected override CountdownData CreateData(Countdown countdown)
        {
            return new() {Current = countdown.Current};
        }

        protected override void ApplyData(Countdown countdown, CountdownData data)
        {
            countdown.Current = data.Current;
        }
    }
}