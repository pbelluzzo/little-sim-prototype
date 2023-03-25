using UnityEngine;
using UnityEngine.UI;

namespace LittleSimPrototype.UI
{
    [RequireComponent(typeof(Button))]
    public class CloseScreenButton : MonoBehaviour
    {
        [SerializeField] private Screen _screen;

        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(HandleClick);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(HandleClick);
        }

        private void HandleClick()
        {
            UINavigationManager.Instance.CloseScreen(_screen);
        }
    }
}
