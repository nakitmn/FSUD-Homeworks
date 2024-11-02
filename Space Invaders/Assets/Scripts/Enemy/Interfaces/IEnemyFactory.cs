namespace Enemy.Interfaces
{
    public interface IEnemyFactory
    {
        Enemy Create();
        void Despawn(Enemy enemy);
    }
}