using UnityEngine;
using UnityEngine.EventSystems;

namespace LittleSimPrototype.UI
{
    public class WindowDrag : MonoBehaviour, IDragHandler
    {
        private RectTransform _rectTransform;

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
        }

        public void OnDrag(PointerEventData eventData)
        {
            _rectTransform.anchoredPosition += eventData.delta;
        }
    }
}
