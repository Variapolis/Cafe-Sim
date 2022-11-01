using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionCaster : MonoBehaviour
{
    [SerializeField] private Camera camera;
    private StarterAssetsInputGenerated playerControls;
    private InputAction interact;
    private void Start()
    {
        playerControls = new StarterAssetsInputGenerated();
        interact = playerControls.Player.Interact;
        interact.Enable();
        interact.performed += Interact;
    }

    void Interact(InputAction.CallbackContext context)
    {
        var cameraTransform = camera.transform;
        if(!Physics.Raycast(cameraTransform.position, cameraTransform.forward, out var hit, 5f)) return;
        if (!hit.collider.TryGetComponent<IInteractable>(out var interactible)) return;
        interactible.Interact();
    }
}
