using Cysharp.Threading.Tasks;

namespace SampleGame
{
    public interface IAnimationCommand
    {
        UniTask Execute();
    }
}