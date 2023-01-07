using System.Collections.Generic;
using Cafe.CookingSystem;
using UnityEngine;

public class FoodTray : MonoBehaviour, IItemInteractable
{
    public List<FoodItem> FoodItems;

    public bool InteractWithItem(GameObject item)
    {
        if (!item.TryGetComponent<FoodItem>(out var ingredient)) return false;
        var rb = item.GetComponent<Rigidbody>();
        item.transform.parent = transform;
        item.transform.position = transform.position;
        rb.isKinematic = true;
        rb.detectCollisions = false;
        FoodItems.Add(ingredient);
        return true;
    }
}