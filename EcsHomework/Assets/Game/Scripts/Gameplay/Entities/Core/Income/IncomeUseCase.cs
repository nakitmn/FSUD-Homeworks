using Unity.Burst;

namespace SampleGame
{
    public static class IncomeUseCase
    {
        public static void UpdateIncome(
            ref IncomePeriod period,
            in IncomeAmount amount,
            PlayerData playerData,
            in float deltaTime
        )
        {
            period.time += deltaTime;
            if (period.time < period.duration)
                return;

            playerData.money += amount.value;
            period.time -= period.duration;
        }
    }
}