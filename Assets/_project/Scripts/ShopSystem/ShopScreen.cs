using LittleSimPrototype.UI;
using TMPro;
using UnityEngine;

namespace LittleSimPrototype.ShopSystem
{
    public class ShopScreen : UIScreen
    {
        [SerializeField] private TextMeshProUGUI _shopTitle;
        [SerializeField] private TextMeshProUGUI _shopDescription;
        [SerializeField] private GameObject _shopItemContainer;
    }
}
