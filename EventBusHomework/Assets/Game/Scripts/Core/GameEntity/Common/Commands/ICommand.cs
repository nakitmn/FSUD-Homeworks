namespace Game.Core
{
    public interface ICommand
    {
        bool Execute(IGameContext gameContext);
    }
}