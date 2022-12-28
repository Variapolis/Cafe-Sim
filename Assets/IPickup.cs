using UnityEngine;

public interface IPickup
{
    public void Pickup(Transform holder);

    public void Drop();
}