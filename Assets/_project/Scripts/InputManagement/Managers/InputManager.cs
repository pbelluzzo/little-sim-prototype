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

            _playerInputActions.CharacterMap.InteractAction.performed += HandleInteractAction;
            _playerInputActions.CharacterMap.InteractAction.Enable();
        }

        private void OnDisable()
        {
            _walkAction.Disable();

            _playerInputActions.CharacterMap.InteractAction.performed -= HandleInteractAction;
            _playerInputActions.CharacterMap.InteractAction.Disable();
        }

        private void FixedUpdate()
        {
            ReadAndNotifyWalkAction();
        }

        private void ReadAndNotifyWalkAction()
        {
            Vector2 walkingVector = _walkAction.ReadValue<Vector2>();
            InputEvents.NotifyMovementInput(walkingVector);
        }

        private void HandleInteractAction(InputAction.CallbackContext context) => InputEvents.NotifyInteractionInput();
    }
}
