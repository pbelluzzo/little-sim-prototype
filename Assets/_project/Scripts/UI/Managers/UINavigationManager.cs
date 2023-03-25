using System.Collections.Generic;
using UnityEngine;

namespace LittleSimPrototype.UI
{
    public class UINavigationManager : MonoBehaviour
    {
        private static UINavigationManager _instance;
        public static UINavigationManager Instance { get => _instance; }

        private List<Screen> _activeScreens = new();

        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(this);
                return;
            }

            _instance = this;
        }

        public void OpenScreen(Screen screen)
        {
            screen.Enable();
            _activeScreens.Add(screen);
        }

        public void CloseScreen(Screen screen)
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
            foreach(Screen screen in _activeScreens)
            {
                screen.Disable();
            }

            _activeScreens.Clear();
        }
    }
}
