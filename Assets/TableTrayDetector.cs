using UnityEngine;

public class TableTrayDetector : MonoBehaviour
{
    [SerializeField] private Table Table;
    private void OnTriggerEnter(Collider other)
    {
        var rb = other.attachedRigidbody;
        if (!rb || !rb.TryGetComponent<FoodTray>(out var tray)) return;
        Table.FoodTray = tray;
    }
}
