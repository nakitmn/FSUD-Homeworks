using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace SampleGame
{
    public class PlayerAbilitiesPresenter : MonoBehaviour
    {
        [SerializeField] private Button _leftButton;
        [SerializeField] private Button _rightButton;
        [SerializeField] private AbilityView[] _views;

        private readonly List<AbilityPresenter> _presenters = new();

        private IGameContext _context;
        private int _startIndex = 0;

        private void Awake()
        {
            _context = GameContext.Instance;
        }

        private void Start()
        {
            _leftButton.onClick.AddListener(OnLeftButtonClicked);
            _rightButton.onClick.AddListener(OnRightButtonClicked);

            IReadOnlyDictionary<string, Ability> abilities = _context.GetCharacter().GetAbilities();
            foreach (var ability in abilities.Values)
            {
                ability.GetCharges().Subscribe(_ => DrawAbilities());
            }

            DrawAbilities();

            for (var i = _presenters.Count; i < _views.Length; i++)
            {
                var view = _views[i];
                view.gameObject.SetActive(false);
            }
        }

        private void Update()
        {
            if (InputUseCase.TryGetAbilitySelectButtonIndex(_context, out var index))
            {
                SelectActivePresenter(index);
            }
        }

        private void OnRightButtonClicked()
        {
            _startIndex += _views.Length;
            DrawAbilities();
        }

        private void OnLeftButtonClicked()
        {
            _startIndex -= _views.Length;
            DrawAbilities();
        }

        private void DrawAbilities()
        {
            ClearPresenters();

            var character = _context.GetCharacter();
            IReadOnlyDictionary<string, Ability> abilities = character.GetAbilities();
            var activeAbilities = abilities.Values.Where(it => it.GetCharges().Value > 0);
            var printAbilities = activeAbilities.Skip(_startIndex)
                .Take(_views.Length);

            int index = 0;

            foreach (var ability in printAbilities)
            {
                var view = _views[index];
                var presenter = new AbilityPresenter(view, ability, character);
                presenter.Enable();
                _presenters.Add(presenter);
                index++;
            }

            var activeCount = activeAbilities.Count();
            if (activeCount <= _views.Length)
            {
                _leftButton.gameObject.SetActive(false);
                _rightButton.gameObject.SetActive(false);
            }
            else
            {
                _leftButton.gameObject.SetActive(_startIndex > 0);
                _rightButton.gameObject.SetActive(_startIndex + _views.Length < activeCount);
            }
        }

        private void OnDestroy()
        {
            ClearPresenters();
        }

        private void ClearPresenters()
        {
            _presenters.ForEach(presenter => presenter.Disable());
            _presenters.Clear();
        }

        public void SelectActivePresenter(int index)
        {
            var activeAbilities = _presenters.Where(it => it.IsVisible)
                .ToArray();

            for (var i = 0; i < activeAbilities.Length; i++)
            {
                if (i == index)
                {
                    activeAbilities[i].Select();
                    return;
                }
            }
        }
    }
}