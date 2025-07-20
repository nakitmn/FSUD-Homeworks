namespace SampleGame
{
    public interface ICommand
    {
        bool Execute(IGameContext gameContext);
    }
}