using JetBrains.Annotations;
using UnityEngine;

public interface IPickup
{
    public void Pickup(Transform holder);

    public void Drop();
    
    public void Drop(Vector3 position);
}