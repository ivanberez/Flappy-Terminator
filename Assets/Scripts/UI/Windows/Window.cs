using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public abstract class Window : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private Button _actionButton;

        public CanvasGroup WindowGroup => _canvasGroup;
        public Button ActionButton => _actionButton;

        private void OnEnable() => _actionButton.onClick.AddListener(OnButtonClick);        
        private void OnDestroy() => _actionButton.onClick.RemoveListener(OnButtonClick);

        public abstract void OnButtonClick();

        public virtual void Open()
        {
            WindowGroup.alpha = 1f;
            ActionButton.interactable = true;
        }

        public virtual void Close()
        {            
            WindowGroup.alpha = 0f;
            ActionButton.interactable = false;
        }
    }
}