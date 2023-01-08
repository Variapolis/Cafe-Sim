using UnityEngine;

public class TraySpawner : MonoBehaviour, IInteractable
{
    [SerializeField] private Vector3 spawnPoint;
    [SerializeField] private GameObject trayPrefab;
    private Vector3 SpawnPoint => spawnPoint + transform.position;

    public bool Interact() => Instantiate(trayPrefab, SpawnPoint, Quaternion.identity);
    private void OnDrawGizmos() => Gizmos.DrawWireSphere(SpawnPoint, 0.1f);
}
