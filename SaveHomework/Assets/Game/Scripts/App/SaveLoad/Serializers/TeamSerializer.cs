using System;
using SampleGame.Common;
using SampleGame.Gameplay;

namespace SampleGame.App
{
    public sealed class TeamSerializer : EntityComponentSerializer<TeamSerializer.Data, Team>
    {
        protected override Data CreateData(Team team)
        {
            return new() {Type = team.Type};
        }

        protected override void ApplyData(Team team, Data data)
        {
            team.Type = data.Type;
        }
        
        [Serializable]
        public struct Data
        {
            public TeamType Type;
        }
    }
}