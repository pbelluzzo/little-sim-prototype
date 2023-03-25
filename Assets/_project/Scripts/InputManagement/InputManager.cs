using UnityEngine.InputSystem;
using UnityEngine;

namespace LittleSimPrototype.InputManagement
{
    public class InputManager : MonoBehaviour
    {
        private PlayerInputActions _playerInputActions;
        private InputAction _walkAction;

        private void Awake()
        {
            _playerInputActions = new();

            _walkAction = _playerInputActions.CharacterMap.WalkAction;
        }

        private void OnEnable()
        {
            _walkAction.Enable();
        }

        private void OnDisable()
        {
            _walkAction.Disable();
        }

        private void Update()
        {
            ReadAndNotifyWalkAction();
        }

        private void ReadAndNotifyWalkAction()
        {
            Vector2 walkingVector = _walkAction.ReadValue<Vector2>();
            InputEvents.NotifyMovementInput(walkingVector);
        }
    }
}
