using System;
using System.Collections.Generic;
using UnityEngine;

namespace Cafe.CookingSystem
{
    public class Ingredient : MonoBehaviour, IItemInteractable, IPickup
    {
        [SerializeField] private Vector3 attachmentOffset;
        [SerializeField] private Ingredient[] whitelist;
        [SerializeField] private Rigidbody _rigidbody;
        public string tempName;
        private Vector3 AttachmentPoint => transform.position + attachmentOffset;
        private List<Ingredient> _ingredients;
        private Ingredient _parent;
        private Ingredient _child;

        public bool HasParentOrChild => _parent || _child;

        private void AttachTo(Ingredient ingredient)
        {
            _parent = ingredient;
            transform.rotation = Quaternion.identity;
            transform.position = ingredient.AttachmentPoint;
            transform.parent = ingredient.transform;
        }

        private bool TryAttachIngredient(Ingredient ingredient)
        {
            if (_child) return _child.TryAttachIngredient(ingredient);
            if (!IsIngredientInWhitelist(ingredient)) return false;
            _child = ingredient;
            ingredient.AttachTo(this);
            return true;
        }

        public bool InteractWithItem(GameObject item) =>
            item.TryGetComponent<Ingredient>(out var ingredient) && TryAttachIngredient(ingredient);

        public void Pickup(Transform holder)
        {
            Debug.Log($"Picked up {name}");
            if (!_parent)
            {
                transform.parent = holder;
                transform.position = holder.transform.position;
                _rigidbody.detectCollisions = false;
                _rigidbody.isKinematic = true;
            }
            else _parent.Pickup(holder);
        }

        public void Drop()
        {
            transform.parent = null;
            _rigidbody.isKinematic = false;
            _rigidbody.detectCollisions = true;
        }

        public void Drop(Vector3 position)
        {
            transform.parent = null;
            _rigidbody.isKinematic = false;
            _rigidbody.detectCollisions = true;
            transform.position = position;
        }

        private bool IsIngredientInWhitelist(Ingredient ingredientToCheck)
        {
            foreach (var ingredient in whitelist)
                if (ingredient.tempName == ingredientToCheck.tempName)
                    return true;
            return false;
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawLine(AttachmentPoint + Vector3.up * 0.01f, AttachmentPoint - Vector3.up * 0.01f);
            Gizmos.DrawLine(AttachmentPoint + Vector3.left * 0.01f, AttachmentPoint - Vector3.left * 0.01f);
            Gizmos.DrawLine(AttachmentPoint + Vector3.forward * 0.01f, AttachmentPoint - Vector3.forward * 0.01f);
        }
    }
}