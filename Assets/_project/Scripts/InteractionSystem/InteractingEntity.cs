using System.Collections.Generic;
using UnityEngine;

namespace LittleSimPrototype.InteractionSystem
{
    public class InteractingEntity : MonoBehaviour
    {
        [SerializeField] private float _interactionRadius;
        [SerializeField] private LayerMask _layerMask;

        private Interactible _highlightedInteractible;

        private void FixedUpdate()
        {
            CheckInteractiblesInRange();
        }

        private void CheckInteractiblesInRange()
        {
            Collider2D[] overlappedColliders = Physics2D.OverlapCircleAll(transform.position, _interactionRadius, _layerMask);

            if (overlappedColliders.Length == 0)
            {
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

            Debug.Log("interacted with : " + closestInteractible);
            _highlightedInteractible = closestInteractible;
            _highlightedInteractible.Highlight();
        }

        private static void CheckInteractibleAndAddToList(List<Interactible> _interactiblesOverlapped, Collider2D collider)
        {
            Interactible interactible;
            collider.TryGetComponent<Interactible>(out interactible);
            if (interactible != null)
            {
                _interactiblesOverlapped.Add(interactible);
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

            //foreach (Interactible interactible in _interactiblesOverlapped)
            //{

            //}

            return closestInteractible;
        }
    }
}
