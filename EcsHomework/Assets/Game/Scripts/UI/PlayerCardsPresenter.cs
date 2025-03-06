using UnityEngine;

namespace SampleGame
{
    public sealed class PlayerCardsPresenter : MonoBehaviour
    {
        [SerializeField] private Transform _container;
        [SerializeField] private UnitCardPresenter _viewPrefab;
        [SerializeField] private UnitCardsCatalog _catalog;

        private void Start()
        {
            foreach (var cardConfig in _catalog.Cards)
            {
                var presenter = Instantiate(_viewPrefab, _container);
                presenter.Construct(cardConfig);
            }
        }
    }
}