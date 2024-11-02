namespace Bullets.Interfaces
{
    public interface IBulletFactory
    {
        Bullet SpawnBullet(BulletParams bulletParams);
        void Despawn(Bullet bullet);
    }
}