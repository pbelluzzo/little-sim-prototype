using LittleSimPrototype.InteractionSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleSimPrototype.ShopSystem
{
    public class ShopKeeper : MonoBehaviour, Interactible
    {
        [SerializeField] private GameObject _interactibleBaloon;
        [SerializeField] private Shop _shop;

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
