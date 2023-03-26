using System;
using UnityEngine;

namespace LittleSimPrototype.InputManagement
{
    public static class InputEvents
    {
        public static Action<Vector2> OnMovementInputEvent;
        public static void NotifyMovementInput(Vector2 value) => OnMovementInputEvent?.Invoke(value);

        public static Action OnInteractionInputEvent;
        public static void NotifyInteractionInput() => OnInteractionInputEvent?.Invoke();
    }
}
