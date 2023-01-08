using System.Collections.Generic;
using Cafe.CookingSystem;
using UnityEngine;

public class FoodTray : MonoBehaviour, IItemInteractable
{
    public List<FoodItem> FoodItems;
    [SerializeField] private Transform[] attachmentPoints;
    private int nextAttachmentPoint;

    public bool InteractWithItem(GameObject item)
    {
        if (nextAttachmentPoint >= attachmentPoints.Length) return false;
        if (!item.TryGetComponent<FoodItem>(out var ingredient)) return false;
        var rb = item.GetComponent<Rigidbody>();
        var attachmentPoint = attachmentPoints[nextAttachmentPoint];
        item.transform.parent = attachmentPoint;
        nextAttachmentPoint++;
        item.transform.position = attachmentPoint.position;
        item.transform.rotation = Quaternion.identity;
        rb.isKinematic = true;
        rb.detectCollisions = false;
        FoodItems.Add(ingredient);
        return true;
    }
}