using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionCaster : MonoBehaviour
{
    [SerializeField] private Camera interactionCamera;
    [SerializeField] private Transform itemHolder;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip interactSuccess;
    [SerializeField] private AudioClip interactFail;
    [SerializeField] private AudioClip itemInteractSuccess;
    [SerializeField] private AudioClip itemPickedUp;
    [SerializeField] private AudioClip itemPlaced;

    private GameObject
        _heldItem; // BUG: Cannot track when item is detached externally. Possibly make this an interface that is held as a variable in pickups.

    private StarterAssetsInputGenerated _playerControls;
    private InputAction _interact;
    private InputAction _pickup;

    private void Start()
    {
        _playerControls = new StarterAssetsInputGenerated();
        _interact = _playerControls.Player.Interact;
        _pickup = _playerControls.Player.Pickup;
        _interact.Enable();
        _pickup.Enable();
        _interact.performed += Interact;
        _pickup.performed += OnPickup;
    }

    private void OnPickup(InputAction.CallbackContext obj)
    {
        if (_heldItem) DropItem();
        else PickupItem();
    }

    private void PickupItem()
    {
        if (_heldItem)
        {
            PlaySound(interactFail);
            return;
        }
        var cameraTransform = interactionCamera.transform;
        if (!Physics.Raycast(cameraTransform.position, cameraTransform.forward, out var hit, 2.5f))
        {
            PlaySound(interactFail);
            return;
        }
        var rb = hit.collider.attachedRigidbody;
        if (!rb || !rb.TryGetComponent<IPickup>(out var pickup))
        {
            PlaySound(interactFail);
            return;
        }
        pickup.Pickup(itemHolder);
        _heldItem = rb.gameObject;
        PlaySound(itemPickedUp);
    }

    private void DropItem()
    {
        var cameraTransform = interactionCamera.transform;
        var heldPickup = _heldItem.GetComponent<IPickup>();
        if (!Physics.Raycast(cameraTransform.position, cameraTransform.forward, out var hit, 2.5f) ||
            !(Vector3.Angle(hit.normal, Vector3.up) < 70f)) return;
        heldPickup.Drop(hit.point + new Vector3(0f, _heldItem.GetComponentInChildren<Collider>().bounds.extents.y, 0f));
        heldPickup.Drop();
        PlaySound(itemPlaced);
        _heldItem = null;
    }

    void Interact(InputAction.CallbackContext context)
    {
        var cameraTransform = interactionCamera.transform;
        if (!Physics.Raycast(cameraTransform.position, cameraTransform.forward, out var hit, 5f)) return;
        if (!hit.collider.attachedRigidbody) return; // BUG: Need to check for Canvas or collider?

        if (_heldItem && hit.collider.attachedRigidbody.TryGetComponent<IItemInteractable>(out var itemInteractable) &&
            itemInteractable.InteractWithItem(_heldItem))
        {
            PlaySound(itemInteractSuccess);
            _heldItem = null;
            return;
        }

        if (hit.collider.attachedRigidbody.TryGetComponent<IInteractable>(out var interactible) &&
            interactible.Interact())
        {
            PlaySound(interactSuccess);
            return;
        }
        PlaySound(interactFail);
    }

    private void PlaySound(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }
}