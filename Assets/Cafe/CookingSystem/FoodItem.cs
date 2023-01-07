using System;
using System.Collections.Generic;
using UnityEngine;

namespace Cafe.CookingSystem
{
    public class FoodItem : MonoBehaviour, IPickup
    {
        [SerializeField] private Vector3 attachmentOffset;
        [SerializeField] private Rigidbody _rigidbody;
        public string IngredientName;
        private Vector3 AttachmentPoint => transform.position + attachmentOffset;

        public void Pickup(Transform holder)
        {
            transform.parent = holder;
            transform.position = holder.transform.position;
            transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
            _rigidbody.detectCollisions = false;
            _rigidbody.isKinematic = true;
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
            transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
            _rigidbody.isKinematic = false;
            _rigidbody.detectCollisions = true;
            transform.position = position;
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawLine(AttachmentPoint + Vector3.up * 0.01f, AttachmentPoint - Vector3.up * 0.01f);
            Gizmos.DrawLine(AttachmentPoint + Vector3.left * 0.01f, AttachmentPoint - Vector3.left * 0.01f);
            Gizmos.DrawLine(AttachmentPoint + Vector3.forward * 0.01f, AttachmentPoint - Vector3.forward * 0.01f);
        }
    }
}