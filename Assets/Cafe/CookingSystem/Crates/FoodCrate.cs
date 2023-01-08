using System;
using UnityEngine;

namespace Cafe.CookingSystem.Crates
{
    [RequireComponent(typeof(Rigidbody))]
    public class FoodCrate : MonoBehaviour, IInteractable
    {
        [SerializeField] private GameObject item;
        [SerializeField] private Vector3 spawnPointOffset;
        [SerializeField] private int count;
        [SerializeField] private Rigidbody _rigidbody;

        private Vector3 SpawnPoint => transform.position + spawnPointOffset;

        private void Reset() => _rigidbody = GetComponent<Rigidbody>();

        public bool Interact()
        {
            // if (count <= 0)
            // {
            //     Destroy(transform);
            //     return false;
            // }
            Instantiate(item, SpawnPoint, Quaternion.identity);
            // count--;
            return true;
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawLine(SpawnPoint + Vector3.up * 0.01f, SpawnPoint - Vector3.up * 0.01f);
            Gizmos.DrawLine(SpawnPoint + Vector3.left * 0.01f, SpawnPoint - Vector3.left * 0.01f);
            Gizmos.DrawLine(SpawnPoint + Vector3.forward * 0.01f, SpawnPoint - Vector3.forward * 0.01f);
        }
    }
}
