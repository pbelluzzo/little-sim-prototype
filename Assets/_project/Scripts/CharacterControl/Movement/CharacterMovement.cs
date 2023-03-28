using UnityEngine;
using LittleSimPrototype.InputManagement;

namespace LittleSimPrototype.CharacterControl
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class CharacterMovement : MonoBehaviour
    {
        [SerializeField] private CharacterMovementConfigs _configs;
        [SerializeField] private CharacterAnimationController _charAnimController;
        
        private Rigidbody2D _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void OnEnable()
        {
            InputEvents.OnMovementInputEvent += HandleMovementInput;
        }

        private void OnDisable()
        {
            InputEvents.OnMovementInputEvent -= HandleMovementInput;
        }

        private void HandleMovementInput(Vector2 movementVector)
        {
            _rigidbody.velocity = movementVector * _configs.MovementSpeed;

            _charAnimController.SetMovementAnimation(movementVector);
        }
    }
}
