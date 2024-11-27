using Modules;
using Zenject;

namespace DefaultNamespace
{
    public sealed class CoinsPool : MonoMemoryPool<Coin>, ICoinsPool
    {
        protected override void OnSpawned(Coin item)
        {
            base.OnSpawned(item);
            item.Generate();
        }

        ICoin IMemoryPool<ICoin>.Spawn()
        {
            return Spawn();
        }

        void IDespawnableMemoryPool<ICoin>.Despawn(ICoin coin)
        {
            var concreteCoin = coin as Coin;
            Despawn(concreteCoin);
        }
    }
}