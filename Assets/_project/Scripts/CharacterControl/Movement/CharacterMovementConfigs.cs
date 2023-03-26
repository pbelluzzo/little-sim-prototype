using UnityEngine;

namespace LittleSimPrototype.CharacterControl
{
    [CreateAssetMenu(fileName = "CharacterMovementConfigs", menuName = "LittleSimPrototype/CharacterControl/MovementConfigs")]
    public class CharacterMovementConfigs : ScriptableObject
    {
        [Header("General")]
        public float MovementSpeed;
    }
}
