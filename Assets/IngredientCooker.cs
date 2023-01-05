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
    private readonly SortedList<int, Coroutine> _cookingItems = new();

    private void OnTriggerEnter(Collider other) // BUG: CAN COOK A BUILT MEAL
    {
        var rb = other.attachedRigidbody;
        if (!rb || !rb.TryGetComponent<Ingredient>(out var ingredient) ||
            _cookingItems.ContainsKey(ingredient.GetInstanceID()) || !conversions.Any(c => c.from.tempName == ingredient.tempName)) return;
        Debug.Log("Added");
        var cr = StartCoroutine(CookItem(ingredient,
            conversions.First(c => c.from.tempName == ingredient.tempName).to));
        _cookingItems.Add(ingredient.GetInstanceID(), cr);
    }

    private void OnTriggerExit(Collider other)
    {
        var rb = other.attachedRigidbody;
        if (!rb || !rb.TryGetComponent<Ingredient>(out var ingredient)) return;
        var id = ingredient.GetInstanceID();
        if (!_cookingItems.ContainsKey(id)) return;
        Debug.Log("Removed");
        StopCoroutine(_cookingItems[id]);
        _cookingItems.Remove(id);
    }

    private IEnumerator CookItem(Ingredient ingredient, Ingredient cookedPrefab)
    {
        yield return new WaitForSeconds(cookTime);
        Debug.Log($"{ingredient.tempName} cooked!");
        Destroy(ingredient.gameObject);
        Instantiate(cookedPrefab, ingredient.transform.position + Vector3.up * 0.01f, ingredient.transform.rotation);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(GetComponent<Collider>().bounds.center, GetComponent<Collider>().bounds.size);
    }

    [Serializable]
    private struct Conversion
    {
        public Ingredient from;
        public Ingredient to;
    }
}