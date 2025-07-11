using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace SampleGame
{
    public sealed class AbilityView : MonoBehaviour
    {
        public event UnityAction OnSelectClicked
        {
            add => _selectButton.onClick.AddListener(value);
            remove => _selectButton.onClick.RemoveListener(value);
        }

        [SerializeField] private Image _icon;
        [SerializeField] private TMP_Text _name;
        [SerializeField] private TMP_Text _count;
        [SerializeField] private GameObject _selectedMarker;
        [SerializeField] private GameObject _cooldownContainer;
        [SerializeField] private ProgressBarFiller _cooldownProgressFiller;
        [SerializeField] private TMP_Text _remainCooldownValue;
        [SerializeField] private Button _selectButton;

        public void SetSelected(bool state)
        {
            _selectedMarker.SetActive(state);
        }

        public void SetCooldownActive(bool state)
        {
            _cooldownContainer.SetActive(state);
        }

        public void SetCooldownProgress(float value)
        {
            _cooldownProgressFiller.FillAmount = value;
        }

        public void SetRemainCooldownValue(string value)
        {
            _remainCooldownValue.text = value;
        }
        
        public void SetIcon(Sprite icon)
        {
            _icon.sprite = icon;
        }
        
        public void SetName(string name)
        {
            _name.text = name;
        }
        
        public void SetCount(string count)
        {
            _count.text = count;
        }
    }
}