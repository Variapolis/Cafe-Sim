using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionCaster : MonoBehaviour
{
    [SerializeField] private Camera interactionCamera;
    [SerializeField] private Transform itemHolder;
    private GameObject _heldItem; // BUG: Cannot track when item is detached externally. Possibly make this an interface that is held as a variable in pickups.
    private StarterAssetsInputGenerated _playerControls;
    private InputAction _interact;

    private void Start()
    {
        _playerControls = new StarterAssetsInputGenerated();
        _interact = _playerControls.Player.Interact;
        _interact.Enable();
        _interact.performed += Interact;
    }

    void Interact(InputAction.CallbackContext context)
    {
        var cameraTransform = interactionCamera.transform;
        if (!Physics.Raycast(cameraTransform.position, cameraTransform.forward, out var hit, 5f)) return;
        
        
        if (_heldItem && hit.collider.attachedRigidbody.TryGetComponent<IItemInteractable>(out var itemInteractable) && itemInteractable.InteractWithItem(_heldItem))
        {
            _heldItem = null;
            return;
        }
        
        if (!_heldItem &&hit.collider.attachedRigidbody.TryGetComponent<IPickup>(out var pickup))
        {
            pickup.Pickup(itemHolder);
            _heldItem = hit.collider.attachedRigidbody.gameObject;
            return;
        }
        
        if (hit.collider.attachedRigidbody.TryGetComponent<IInteractable>(out var interactible)) interactible.Interact();
    }
}