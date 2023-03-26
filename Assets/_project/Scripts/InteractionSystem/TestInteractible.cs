using TMPro;
using UnityEngine;

namespace LittleSimPrototype.InteractionSystem
{
    public class TestInteractible : MonoBehaviour, Interactible
    {
        [SerializeField] private GameObject _interactibleBaloon;

        private bool _isInteractible;
        public bool IsInteractible { get => _isInteractible; }

        public void Highlight()
        {
            _interactibleBaloon.SetActive(true);
        }

        public void EndHighlight()
        {
            _interactibleBaloon.SetActive(false);
        }

        public void Interact()
        {
            Debug.Log("Someone Interacted with me");
        }
    }
}
