using System.Collections.Generic;
using UnityEngine;

namespace LittleSimPrototype.UI
{
    public class UINavigationManager : MonoBehaviour
    {
        private static UINavigationManager _instance;
        public static UINavigationManager Instance { get => _instance; }

        private List<UIScreen> _activeScreens = new();

        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(this);
                return;
            }

            _instance = this;
        }

        public void OpenScreen(UIScreen screen)
        {
            screen.Enable();
            _activeScreens.Add(screen);
        }

        public void CloseScreen(UIScreen screen)
        {
            if (!_activeScreens.Contains(screen))
            {
                return;
            }

            screen.Disable();
            _activeScreens.Remove(screen);
        }

        public void CloseAll()
        {
            foreach(UIScreen screen in _activeScreens)
            {
                screen.Disable();
            }

            _activeScreens.Clear();
        }
    }
}
