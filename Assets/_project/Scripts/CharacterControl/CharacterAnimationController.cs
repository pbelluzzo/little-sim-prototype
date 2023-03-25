using UnityEngine;

namespace LittleSimPrototype.CharacterControl
{
    public class CharacterAnimationController : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        [SerializeField] private string _idleAnimatorParameter;
        [SerializeField] private string _walkAnimatorParameter;

        private Vector3 _initialScale;

        private void Awake()
        {
            _initialScale = transform.localScale;
        }

        public void SetMovementAnimation(Vector2 movementVector)
        {
            if (movementVector == Vector2.zero)
            {
                SetIdleAnim();
                return;
            }

            bool isWalkingLeft = movementVector.x < 0 ? true : false;
            Vector3 invertedScale = new Vector3(-_initialScale.x, _initialScale.y, _initialScale.z);

            transform.localScale = isWalkingLeft ? _initialScale : invertedScale;
            _animator.SetTrigger(_walkAnimatorParameter);
        }

        private void SetIdleAnim()
        {
            if (string.IsNullOrEmpty(_idleAnimatorParameter))
            {
                Debug.LogWarning("Idle Parameter Is Not Set Up");
                return;
            }

            _animator.SetTrigger(_idleAnimatorParameter);
        }

        private void SetWalkAnim()
        {
            if (string.IsNullOrEmpty(_walkAnimatorParameter))
            {
                Debug.LogWarning("Walk Parameter Is Not Set Up");
                return;
            }

            _animator.SetTrigger(_walkAnimatorParameter);
        }
    }
}
