using System.Collections.Generic;
using Cysharp.Threading.Tasks;

namespace SampleGame.App
{
    public interface IGameRepository
    {
        UniTask<SaveResult> SetState(Dictionary<string, string> gameState);
        UniTask<LoadResult> GetState(string version);
        
        public readonly struct SaveResult
        {
            public readonly bool Success; 
            public readonly string Version;

            public SaveResult(bool success, string version)
            {
                Success = success;
                Version = version;
            }
        }
        
        public readonly struct LoadResult
        {
            public readonly bool Success; 
            public readonly string Version; 
            public readonly Dictionary<string, string> GameState;

            public LoadResult(bool success, string version, Dictionary<string, string> gameState)
            {
                Success = success;
                Version = version;
                GameState = gameState;
            }
        }
    }
}