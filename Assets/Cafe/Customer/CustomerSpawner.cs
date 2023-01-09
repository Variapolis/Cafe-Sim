using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] customerPrefabs;
    
    void Start() => StartCoroutine(SpawnCustomer());

    private IEnumerator SpawnCustomer()
    {
        while (true)
        {
            if (CustomerTracker.Total > 20) continue;
            Instantiate(customerPrefabs[Random.Range(0, customerPrefabs.Length)], transform.position, transform.rotation);
            yield return new WaitForSeconds(2f);
        }
    }
}