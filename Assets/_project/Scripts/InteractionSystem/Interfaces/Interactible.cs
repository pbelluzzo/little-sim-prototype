using UnityEngine;

namespace LittleSimPrototype.InteractionSystem
{
    public interface Interactible
    {
        Transform transform { get; }

        bool IsInteractible { get; }

        void Highlight() { }

        void EndHighlight() { }

        void Interact() { }

        void EndInteraction() { }
    }
}
