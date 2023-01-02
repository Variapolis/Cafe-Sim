using System;
using System.Collections.Generic;
using System.Linq;
using Cafe.CookingSystem;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class IngredientCooker : MonoBehaviour
{
    [SerializeField] private Conversion[] conversions;
    private readonly SortedList<Ingredient, float> _cookingItems = new();

    private void OnTriggerEnter(Collider other) // BUG: CAN COOK A BUILT MEAL
    {
        if (!other.attachedRigidbody) return;
        Debug.Log("Has RigidBody");
        if (!other.attachedRigidbody.TryGetComponent<Ingredient>(out var ingredient) ||
            !conversions.Any(c => c.from.tempName == ingredient.tempName)) return;
        Debug.Log("Added");
        _cookingItems.Add(ingredient, Time.time);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.attachedRigidbody) return;
        if (!other.attachedRigidbody.TryGetComponent<Ingredient>(out var ingredient) ||
            !_cookingItems.ContainsKey(ingredient)) return;
        Debug.Log("Removed");
        _cookingItems.Remove(ingredient);
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