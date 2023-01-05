using System;
using UnityEngine;

namespace Cafe.CookingSystem.Crates
{
    [RequireComponent(typeof(Rigidbody))]
    public class FoodCrate : MonoBehaviour, IInteractable, IPickup
    {
        [SerializeField] private GameObject item;
        [SerializeField] private Vector3 spawnPointOffset;
        [SerializeField] private int count;
        [SerializeField] private Rigidbody _rigidbody;

        private Vector3 SpawnPoint => transform.position + spawnPointOffset;

        private void Reset() => _rigidbody = GetComponent<Rigidbody>();

        public bool Interact()
        {
            if (count <= 0)
            {
                Destroy(transform);
                return false;
            }
            Instantiate(item, SpawnPoint, Quaternion.identity);
            count--;
            return true;
        }

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
            transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
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
        
        private void OnDrawGizmos()
        {
            Gizmos.DrawLine(SpawnPoint + Vector3.up * 0.01f, SpawnPoint - Vector3.up * 0.01f);
            Gizmos.DrawLine(SpawnPoint + Vector3.left * 0.01f, SpawnPoint - Vector3.left * 0.01f);
            Gizmos.DrawLine(SpawnPoint + Vector3.forward * 0.01f, SpawnPoint - Vector3.forward * 0.01f);
        }
    }
}
