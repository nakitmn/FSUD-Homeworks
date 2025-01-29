using System;
using Cysharp.Threading.Tasks;
using SampleGame.App;

namespace Game.Gameplay
{
    public sealed class ControlsPresenter : IControlsPresenter
    {
        private readonly GameSaveLoader _saveLoader;

        public ControlsPresenter(GameSaveLoader saveLoader)
        {
            _saveLoader = saveLoader;
        }

        public void Save(Action<bool, int> callback)
        {
            SaveAsync(callback).Forget();
        }

        public void Load(string versionText, Action<bool, int> callback)
        {
            LoadAsync(versionText, callback).Forget();
        }

        private async UniTaskVoid SaveAsync(Action<bool, int> callback)
        {
            await _saveLoader.Save();
            callback?.Invoke(false, -1);
        }

        private async UniTaskVoid LoadAsync(string versionText, Action<bool, int> callback)
        {
            await _saveLoader.Load(versionText);
            callback?.Invoke(false, -1);
        }
    }
}