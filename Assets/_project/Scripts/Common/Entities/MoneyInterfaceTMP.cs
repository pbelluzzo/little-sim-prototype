using LittleSimPrototype.Inventory;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace LittleSimPrototype
{
    public class MoneyInterfaceTMP : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _moneyText;

        private void OnEnable()
        {
            InventoryEvents.OnPlayerMoneyUpdateEvent += HandlePlayerMoneyUpdate;   
        }

        private void OnDisable()
        {
            InventoryEvents.OnPlayerMoneyUpdateEvent -= HandlePlayerMoneyUpdate;   
        }

        private void HandlePlayerMoneyUpdate(int money)
        {
            _moneyText.text = money.ToString() + ",00";
        }
    }
}
