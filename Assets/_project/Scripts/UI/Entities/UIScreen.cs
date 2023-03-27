using UnityEngine;

namespace LittleSimPrototype.UI
{
    public class UIScreen : MonoBehaviour
    {
        [SerializeField] protected GameObject _screenGameObject;

        private void Awake()
        {
            Disable();
        }

        public virtual void Enable()
        {
            _screenGameObject.SetActive(true);
        }

        public virtual void Disable()
        {
            _screenGameObject.SetActive(false);
        }

    }
}
