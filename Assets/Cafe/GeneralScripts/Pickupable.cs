using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Pickupable : MonoBehaviour, IPickup
{
    [SerializeField] private Rigidbody _rigidbody;

    private void Reset() => _rigidbody = GetComponent<Rigidbody>();

    public void Pickup(Transform holder)
    {
        transform.parent = holder;
        transform.position = holder.transform.position;
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
        _rigidbody.detectCollisions = false;
        _rigidbody.isKinematic = true;
    }

    public void Drop()
    {
        transform.parent = null;
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
        _rigidbody.isKinematic = false;
        _rigidbody.detectCollisions = true;
    }

    public void Drop(Vector3 position)
    {
        transform.parent = null;
        _rigidbody.isKinematic = false;
        _rigidbody.detectCollisions = true;
        transform.position = position;
    }
}