using LittleSimPrototype.InputManagement;
using System.Collections.Generic;
using UnityEngine;

namespace LittleSimPrototype.InteractionSystem
{
    public class InteractingEntity : MonoBehaviour
    {
        [SerializeField] private float _interactionRadius;
        [SerializeField] private Vector3 _interactionOffset;
        [SerializeField] private LayerMask _layerMask;

        private Interactible _highlightedInteractible;

        private void OnEnable()
        {
            InputEvents.OnInteractionInputEvent += HandleInteractionInput;
        }

        private void OnDisable()
        {
            InputEvents.OnInteractionInputEvent -= HandleInteractionInput;
        }

        private void FixedUpdate()
        {
            CheckInteractiblesInRange();
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position + _interactionOffset, _interactionRadius);
        }

        private void CheckInteractiblesInRange()
        {
            Collider2D[] overlappedColliders = Physics2D.OverlapCircleAll(transform.position + _interactionOffset, _interactionRadius, _layerMask);

            if (overlappedColliders.Length == 0)
            {
                RemoveHighlightedObject();
                return;
            }

            List<Interactible> interactiblesOverlapped = new();

            foreach (Collider2D collider in overlappedColliders)
            {
                CheckInteractibleAndAddToList(interactiblesOverlapped, collider);
            }

            if (interactiblesOverlapped.Count == 0)
            {
                return;
            }

            Interactible closestInteractible = interactiblesOverlapped[0];

            if (interactiblesOverlapped.Count > 1)
            {
                closestInteractible = GetClosestInteractible(interactiblesOverlapped, closestInteractible);
            }

            _highlightedInteractible = closestInteractible;
            _highlightedInteractible.Highlight();
        }

        private void RemoveHighlightedObject()
        {
            if (_highlightedInteractible == null)
            {
                return;
            }

            _highlightedInteractible.EndHighlight();
            _highlightedInteractible = null;
        }

        private static void CheckInteractibleAndAddToList(List<Interactible> interactiblesOverlapped, Collider2D collider)
        {
            Interactible interactible;
            collider.TryGetComponent<Interactible>(out interactible);
            if (interactible != null)
            {
                interactiblesOverlapped.Add(interactible);
            }
        }

        private Interactible GetClosestInteractible(List<Interactible> interactiblesOverlapped, Interactible closestInteractible)
        {
            float distanceFromClosest = Vector2.Distance(transform.position, closestInteractible.transform.position);

            for (int i = 1; i < interactiblesOverlapped.Count; i++)
            {
                float distanceFromActual = Vector2.Distance(transform.position, interactiblesOverlapped[i].transform.position);

                closestInteractible = distanceFromActual > distanceFromClosest ? interactiblesOverlapped[i] : closestInteractible;
            }

            return closestInteractible;
        }

        private void HandleInteractionInput()
        {
            if (_highlightedInteractible == null)
            {
                return;
            }

            _highlightedInteractible.Interact();
        }
    }
}
