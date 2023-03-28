using LittleSimPrototype.InteractionSystem;
using LittleSimPrototype.UI;
using UnityEngine;

namespace LittleSimPrototype.ShopSystem
{
    public class ShopKeeper : MonoBehaviour, Interactible
    {
        [SerializeField] private ShopScreen _shopScreen;
        [SerializeField] private GameObject _interactibleBaloon;
        [SerializeField] private Shop _shop;

        [SerializeField] private bool _isInteractible = default;
        public bool IsInteractible { get => _isInteractible; }

        private void Start()
        {
            _shopScreen.SetUpShopScreen(_shop);
        }

        public void Highlight()
        {
            if (!_isInteractible)
            {
                return; 
            }

            _interactibleBaloon.SetActive(true);
        }

        public void EndHighlight()
        {
            if (!_isInteractible)
            {
                return;
            }

            _interactibleBaloon.SetActive(false);
        }

        public void Interact()
        {
            if (!_isInteractible)
            {
                return;
            }

            UINavigationManager.Instance.OpenScreen(_shopScreen);
        }
    }
}
