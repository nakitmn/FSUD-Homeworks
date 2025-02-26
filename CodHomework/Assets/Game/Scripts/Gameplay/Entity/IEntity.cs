namespace Game.Gameplay
{
    public interface IEntity
    {
        T Get<T>();
        bool TryGet<T>(out T component);
    }
}