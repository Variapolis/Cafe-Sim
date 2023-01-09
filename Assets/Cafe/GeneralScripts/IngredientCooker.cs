using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Cafe.CookingSystem;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class IngredientCooker : MonoBehaviour
{
    [SerializeField] private Conversion[] conversions;

    [SerializeField] private float cookTime;
    [SerializeField] private AudioSource audioSource;
    private readonly SortedList<int, Coroutine> _cookingItems = new();

    private void OnTriggerEnter(Collider other) // BUG: CAN COOK A BUILT MEAL
    {
        var rb = other.attachedRigidbody;
        if (!rb || !rb.TryGetComponent<FoodItem>(out var ingredient) ||
            _cookingItems.ContainsKey(ingredient.GetInstanceID()) || !conversions.Any(c => c.from.IngredientName == ingredient.IngredientName)) return;
        Debug.Log("Added");
        var cr = StartCoroutine(CookItem(ingredient,
            conversions.First(c => c.from.IngredientName == ingredient.IngredientName).to));
        _cookingItems.Add(ingredient.GetInstanceID(), cr);
    }

    private void OnTriggerExit(Collider other)
    {
        var rb = other.attachedRigidbody;
        if (!rb || !rb.TryGetComponent<FoodItem>(out var ingredient)) return;
        var id = ingredient.GetInstanceID();
        if (!_cookingItems.ContainsKey(id)) return;
        Debug.Log("Removed");
        StopCoroutine(_cookingItems[id]);
        _cookingItems.Remove(id);
    }

    private IEnumerator CookItem(FoodItem foodItem, FoodItem cookedPrefab)
    {
        audioSource.Play();
        yield return new WaitForSeconds(cookTime);
        Debug.Log($"{foodItem.IngredientName} cooked!");
        Destroy(foodItem.gameObject);
        Instantiate(cookedPrefab, foodItem.transform.position + Vector3.up * 0.01f, foodItem.transform.rotation);
        audioSource.Stop();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(GetComponent<Collider>().bounds.center, GetComponent<Collider>().bounds.size);
    }

    [Serializable]
    private struct Conversion
    {
        public FoodItem from;
        public FoodItem to;
    }
}