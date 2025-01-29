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
            var saveResult = await _saveLoader.Save();
            callback?.Invoke(saveResult.Success, int.Parse(saveResult.Version));
        }

        private async UniTaskVoid LoadAsync(string versionText, Action<bool, int> callback)
        {
            var loadResult = await _saveLoader.Load(versionText);
            callback?.Invoke(loadResult.Success, int.Parse(loadResult.Version));
        }
    }
}