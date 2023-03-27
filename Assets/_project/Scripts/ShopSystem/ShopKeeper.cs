using LittleSimPrototype.InteractionSystem;
using LittleSimPrototype.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleSimPrototype.ShopSystem
{
    public class ShopKeeper : MonoBehaviour, Interactible
    {
        [SerializeField] private ShopScreen _shopScreen;
        [SerializeField] private GameObject _interactibleBaloon;
        [SerializeField] private Shop _shop;

        private bool _isInteractible;
        public bool IsInteractible { get => _isInteractible; }

        private void Start()
        {
            _shopScreen.SetUpShopScreen(_shop);
        }

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
            UINavigationManager.Instance.OpenScreen(_shopScreen);
        }
    }
}
