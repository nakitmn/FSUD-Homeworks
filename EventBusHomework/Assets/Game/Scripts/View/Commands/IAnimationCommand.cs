using Cysharp.Threading.Tasks;

namespace Game.View
{
    public interface IAnimationCommand
    {
        UniTask Execute();
    }
}