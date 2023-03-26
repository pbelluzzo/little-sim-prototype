using UnityEngine;

namespace LittleSimPrototype.InteractionSystem
{
    public interface Interactible
    {
        Transform transform { get; }

        void Highlight() { }
        
        void Interact() { }

        void EndInteraction() { }
    }
}
